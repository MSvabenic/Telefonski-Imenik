using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.ViewModels;
using System;

namespace TelefonskiImenik.Controllers
{
    public class KontaktController : Controller
    {
        public ActionResult DodajOsobu()
        {
            var viewModel = new OsobaViewModel();

            return View(viewModel);
        }

        public ActionResult DodajBroj()
        {
            var viewModel = new BrojViewModel();

            return View(viewModel);
        }

        public ActionResult DetaljiKontakta(Guid id)
        {
            return View();
        }

        public ActionResult SviKontakti()
        {
            return View();
        }
    }
}