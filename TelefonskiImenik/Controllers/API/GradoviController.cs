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
    [RoutePrefix("Grad")]
    public class GradController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GradController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Dohvat svih podataka o svim gradovima
        /// </summary>
        /// <returns></returns>
        [Route("GetGradovi")]
        [HttpGet]
        public IHttpActionResult GetGradovi()
        {
            var grad = _context.Grad.OrderBy(x => x.Naziv).ToList();

            if (grad == null)
            {
                return BadRequest("Error has occured!");
            }

            return Json(grad);
        }

        [Route("GetGrad/{id}")]
        [HttpGet]
        public IHttpActionResult GetGrad([FromUri] Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var grad = _context.Grad.Where(x => x.Id == id).Select(a => new { a.Naziv, a.Opis });

            if (grad == null)
            {
                return BadRequest();
            }

            return Json(grad);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grad"></param>
        /// <returns></returns>
        [Route("DodajNoviGrad")]
        [HttpPost]
        public IHttpActionResult DodajNoviGrad([FromBody]Grad grad)
        {
            if (ModelState.IsValid)
            {
                _context.Grad.Add(grad);
                _context.SaveChanges();

                return Ok(grad);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Brisanje grada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("IzbrisiGrad/{id}")]
        [HttpDelete]
        public IHttpActionResult IzbrisiGrad([FromUri] Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var grad = _context.Grad.Where(x => x.Id == id).FirstOrDefault();

            if (grad == null)
            {
                return BadRequest();
            }

            _context.Grad.Remove(grad);
            _context.SaveChanges();

            return Ok(grad);
        }
    }
}
