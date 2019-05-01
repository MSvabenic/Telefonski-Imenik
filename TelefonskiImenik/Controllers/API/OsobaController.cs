using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TelefonskiImenik.Models;

namespace TelefonskiImenik.Controllers.API
{
    [Authorize]
    [RoutePrefix("Osoba")]
    public class OsobaController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public OsobaController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Podaci za punjenje dropdowna
        /// </summary>
        /// <returns></returns>
        [Route("GetOsoba")]
        [HttpGet]
        public IHttpActionResult GetOsoba()
        {
            var UserId = User.Identity.GetUserId();
            var osoba = _context.Osobe.Where(x => x.UserId == UserId).Select(x => new { x.Id, x.Ime, x.Prezime }).ToList(); //probati dohvatiti cjeli objekt

            if (osoba == null)
            {
                return BadRequest("Error has occured!");
            }

            return Json(osoba);
        }

        /// <summary>
        /// Slika osobe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetOsobaSlika/{id}")]
        [HttpGet]
        public IHttpActionResult GetOsobaSlika(Guid id)
        {
            var osoba = _context.Osobe.Where(x => x.Id == id).Select(x => new { x.Slika }).ToList();

            if (osoba == null)
            {
                return BadRequest("Error has occured!");
            }

            return Json(osoba);
        }

        /// <summary>
        /// Podaci za tablični prikaz
        /// </summary>
        /// <returns></returns>
        [Route("GetOsobe")]
        [HttpGet]
        public IHttpActionResult GetOsobe()
        {
            var UserId = User.Identity.GetUserId();

            var sviBrojevi = from bro in _context.BrojeviOsobe.ToList()
                             group bro by bro.OsobaId into g
                             select new
                             {
                                 OsobaId = g.Key,
                                 Broj = string.Join(",", g.Select(x => x.Broj))
                             };

            var osoba = from brojevi in sviBrojevi
                        join osobe in _context.Osobe on brojevi.OsobaId equals osobe.Id
                        where UserId == osobe.UserId
                        select new
                        {
                            OsobaId = osobe.Id,
                            Ime = osobe.Ime,
                            Prezime = osobe.Prezime,
                            Grad = osobe.Grad.Naziv,
                            Broj = brojevi.Broj
                        };

            if (osoba == null)
            {
                return BadRequest("Error has occured!");
            }

            return Json(osoba);
        }

        /// <summary>
        /// Ppodaci o osobi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetOsoba/{id}")]
        [HttpGet]
        public IHttpActionResult GetOsoba(Guid id)
        {
            var UserId = User.Identity.GetUserId();

            var osoba = _context.Osobe.Where(x => x.Id == id && x.UserId == UserId).Select(x => new { x.Ime, x.Prezime, x.Grad.Naziv, x.Opis }).ToList();

            if (osoba == null)
            {
                return BadRequest("Error has occured!");
            }

            return Json(osoba);
        }

        /// <summary>
        /// Spremanje podataka o osobi
        /// </summary>
        /// <param name="osoba"></param>
        /// <returns></returns>
        [Route("DodajOsobu")]
        [HttpPost]
        public IHttpActionResult DodajOsobu([FromBody]Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                _context.Osobe.Add(osoba);
                _context.SaveChanges();

                return Ok(osoba);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Brisanje osobe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("IzbrisiOsobu/{id}")]
        [HttpDelete]
        public IHttpActionResult IzbrisiOsobu([FromUri] Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var UserId = User.Identity.GetUserId();

            var osoba = _context.Osobe.Where(x => x.Id == id && x.UserId == UserId).FirstOrDefault();

            if (osoba == null)
            {
                return BadRequest();
            }

            _context.Osobe.Remove(osoba);
            _context.SaveChanges();

            return Ok(osoba);
        }
    }
}
