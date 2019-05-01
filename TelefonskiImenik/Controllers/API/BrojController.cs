using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using TelefonskiImenik.Models;

namespace TelefonskiImenik.Controllers.API
{
    [Authorize]
    [RoutePrefix("Broj")]
    public class BrojController : ApiController
    {
        private readonly ApplicationDbContext _context;
       
        public BrojController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetTipBroj")]
        [HttpGet]
        public IHttpActionResult GetTipBroj()
        {
            var tipBroj = _context.BrojTipovi.ToList();

            if (tipBroj == null)
            {
                return BadRequest("Error has occured!");
            }

            return Json(tipBroj);
        }

        [Route("GetBroj/{id}")]
        [HttpGet]
        public IHttpActionResult GetBroj([FromUri] Guid id)
        {
            var broj = (from brojevi in _context.BrojeviOsobe
                        join brojtip in _context.BrojTipovi on brojevi.BrojTipId equals brojtip.Id
                        where brojevi.OsobaId == id
                        select new
                        {
                            Broj = brojevi.Broj,
                            BrojTip = brojtip.Naziv,
                            OpisBroja = brojevi.Opis
                        }).ToList();


            if (broj == null)
            {
                return BadRequest("Error has occured!");
            }

            return Json(broj);
        }

        [Route("DodajBroj")]
        [HttpPost]
        public IHttpActionResult DodajBroj([FromBody]BrojeviOsoba broj)
        {
            if (ModelState.IsValid)
            {
                _context.BrojeviOsobe.Add(broj);
                _context.SaveChanges();

                return Ok(broj);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}


