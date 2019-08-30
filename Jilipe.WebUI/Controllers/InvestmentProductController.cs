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
    public class InvestmentProductController : Controller
    {
        private InvestmentCategoryDataSource contextInvestmentCategory;
        private InvestmentProductDataSource contextInvestmentProduct;
        private User user;

        public InvestmentProductController()
        {
            this.contextInvestmentCategory = new InvestmentCategoryDataSource();
            this.contextInvestmentProduct = new InvestmentProductDataSource();
            this.user = new User();
        }

        // GET: Product
        public ActionResult Index()
        {
            ViewData["InvestmentCategories"] = contextInvestmentCategory.GetAll();
            return View();
        }

        #region Product Action Methods
        public ActionResult EditingInvestmentProductPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(contextInvestmentProduct.GetAll().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentProductPopup_Create([DataSourceRequest] DataSourceRequest request, InvestmentProductManagerViewModel investmentProductViewModel)
        {
            if (investmentProductViewModel != null && ModelState.IsValid)
            {
                contextInvestmentProduct.AddEdit(investmentProductViewModel, user);
            }
            investmentProductViewModel.InvestmentCategory.Id = investmentProductViewModel.ProductCategoryId;
            return Json(new[] { investmentProductViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentProductPopup_Update([DataSourceRequest] DataSourceRequest request, InvestmentProductManagerViewModel investmentProductViewModel)
        {
            if (investmentProductViewModel != null && ModelState.IsValid)
            {
                contextInvestmentProduct.AddEdit(investmentProductViewModel, user);
            }
            investmentProductViewModel.InvestmentCategory.Id = investmentProductViewModel.ProductCategoryId;
            return Json(new[] { investmentProductViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInvestmentProductPopup_Destroy([DataSourceRequest] DataSourceRequest request, InvestmentProductManagerViewModel investmentProductViewModel)
        {
            if (investmentProductViewModel != null)
            {
                contextInvestmentProduct.Delete(investmentProductViewModel.Id, user);
            }

            return Json(new[] { investmentProductViewModel }.ToDataSourceResult(request, ModelState));
        }
        #endregion
    }
}