using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jilipe.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Investments()
        {
            return View();
        }

        public ActionResult Wishlist()
        {
            return View();
        }
    }
}