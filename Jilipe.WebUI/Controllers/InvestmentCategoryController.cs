using AgriInvestment.Core.ViewModels;
using Jilipe.Core.Models;
using Jilipe.Core.ViewModels;
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
    public class InvestmentCategoryController : Controller
    {
        private InvestmentCategoryDataSource contextInvestmentCategory;
        private User user;

        public InvestmentCategoryController()
        {
            this.contextInvestmentCategory = new InvestmentCategoryDataSource();
            this.user = new User();
        }

        // GET: ProductSetup
        public ActionResult Index()
        {
            return View();
        }

        #region Product Category Action Methods
        public ActionResult EditingInvestmentCategoryPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(contextInvestmentCategory.GetAll().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentCategoryPopup_Create([DataSourceRequest] DataSourceRequest request, InvestmentCategoryManagerViewModel InvestmentCategoryViewModel)
        {
            if (InvestmentCategoryViewModel != null && ModelState.IsValid)
            {
                contextInvestmentCategory.AddEdit(InvestmentCategoryViewModel, user);
                ViewData["ProductCategories"] = contextInvestmentCategory.GetAll();
            }

            return Json(new[] { InvestmentCategoryViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentCategoryPopup_Update([DataSourceRequest] DataSourceRequest request, InvestmentCategoryManagerViewModel InvestmentCategoryViewModel)
        {
            if (InvestmentCategoryViewModel != null && ModelState.IsValid)
            {
                contextInvestmentCategory.AddEdit(InvestmentCategoryViewModel, user);
                ViewData["ProductCategories"] = contextInvestmentCategory.GetAll();
            }

            return Json(new[] { InvestmentCategoryViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentCategoryPopup_Destroy([DataSourceRequest] DataSourceRequest request, InvestmentCategoryManagerViewModel InvestmentCategoryViewModel)
        {
            if (InvestmentCategoryViewModel != null)
            {
                contextInvestmentCategory.Delete(InvestmentCategoryViewModel.Id, user);
            }

            return Json(new[] { InvestmentCategoryViewModel }.ToDataSourceResult(request, ModelState));
        }
        #endregion
    }
}