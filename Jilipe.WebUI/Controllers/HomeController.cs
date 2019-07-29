using Jilipe.DataAccess.SQLDapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriInvestment.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private InvestmentCycleDataSource contextInvestmentCycle;

        public HomeController()
        {
            this.contextInvestmentCycle = new InvestmentCycleDataSource();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Legal()
        {
            return View();
        }

        public ActionResult CSR()
        {
            return View();
        }

        public ActionResult HowItWorks()
        {
            return View();
        }

        public ActionResult InvestmentOpportunities()
        {
            return View();
        }

        public ActionResult AssuredReturns()
        {
            return View();
        }

        public ActionResult InvestmentCycleCard_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(contextInvestmentCycle.GetAll().ToDataSourceResult(request));
        }
    }
}