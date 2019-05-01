using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonskiImenik.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class GradController : Controller
    {
        public ActionResult DodajGrad()
        {
            var viewModel = new GradViewModel();

            return View(viewModel);
        }

        public ActionResult DetaljiGrada(Guid id)
        {
            return View();
        }

        public ActionResult SviGradovi()
        {
            return View();
        }
    }
}