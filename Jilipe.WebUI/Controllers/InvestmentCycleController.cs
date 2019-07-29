using AgriInvestment.Core.ViewModels;
using Jilipe.Core.Models;
using Jilipe.DataAccess.SQLDapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jilipe.WebUI.Controllers
{
    public class InvestmentCycleController : Controller
    {
        private InvestmentProductDataSource contextInvestmentProduct;
        private InvestmentCycleDataSource contextInvestmentCycle;
        private User user;

        public InvestmentCycleController()
        {
            this.contextInvestmentProduct = new InvestmentProductDataSource();
            this.contextInvestmentCycle = new InvestmentCycleDataSource();
            this.user = new User();
        }

        // GET: InvestmentCycle
        public ActionResult Index()
        {
            ViewData["InvestmentProducts"] = contextInvestmentProduct.GetAll();
            return View();
        }

        #region Investment Cycle Action Methods
        public ActionResult EditingInvestmentCyclePopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(contextInvestmentCycle.GetAll().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentCyclePopup_Create([DataSourceRequest] DataSourceRequest request, InvestmentCycleManagerViewModel investmentCycleViewModel)
        {
            if (investmentCycleViewModel != null && ModelState.IsValid)
            {
                contextInvestmentCycle.AddEdit(investmentCycleViewModel, user);
            }

            return Json(new[] { investmentCycleViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentCyclePopup_Update([DataSourceRequest] DataSourceRequest request, InvestmentCycleManagerViewModel investmentCycleViewModel)
        {
            if (investmentCycleViewModel != null && ModelState.IsValid)
            {
                contextInvestmentCycle.AddEdit(investmentCycleViewModel, user);
            }

            return Json(new[] { investmentCycleViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentCyclePopup_Destroy([DataSourceRequest] DataSourceRequest request, InvestmentCycleManagerViewModel investmentCycleViewModel)
        {
            if (investmentCycleViewModel != null)
            {
                contextInvestmentCycle.Delete(investmentCycleViewModel.Id, user);
            }

            return Json(new[] { investmentCycleViewModel }.ToDataSourceResult(request, ModelState));
        }
        #endregion
    }
}