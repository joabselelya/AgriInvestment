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
    public class ProductSetupController : Controller
    {
        private ProductCategoryDataSource contextProductCategory;
        private ProductDataSource contextProduct;
        private InvestmentCycleDataSource contextInvestmentCycle;
        private User user;

        public ProductSetupController()
        {
            this.contextProductCategory = new ProductCategoryDataSource();
            this.contextProduct = new ProductDataSource();
            this.contextInvestmentCycle = new InvestmentCycleDataSource();
            this.user = new User();
        }

        // GET: ProductSetup
        public ActionResult Index()
        {
            ViewData["ProductCategories"] = contextProductCategory.GetAll();
            ViewData["ProductCategories"] = contextProductCategory.GetAll();
            ViewData["Products"] = contextProduct.GetAll();
            return View();
        }

        #region Product Category Action Methods
        public ActionResult EditingProductCategoryPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(contextProductCategory.GetAll().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingProductCategoryPopup_Create([DataSourceRequest] DataSourceRequest request, ProductCategoryManagerViewModel productCategoryViewModel)
        {
            if (productCategoryViewModel != null && ModelState.IsValid)
            {
                contextProductCategory.AddEdit(productCategoryViewModel, user);
                ViewData["ProductCategories"] = contextProductCategory.GetAll();
            }

            return Json(new[] { productCategoryViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingProductCategoryPopup_Update([DataSourceRequest] DataSourceRequest request, ProductCategoryManagerViewModel productCategoryViewModel)
        {
            if (productCategoryViewModel != null && ModelState.IsValid)
            {
                contextProductCategory.AddEdit(productCategoryViewModel, user);
                ViewData["ProductCategories"] = contextProductCategory.GetAll();
            }

            return Json(new[] { productCategoryViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingProductCategoryPopup_Destroy([DataSourceRequest] DataSourceRequest request, ProductCategoryManagerViewModel productCategoryViewModel)
        {
            if (productCategoryViewModel != null)
            {
                contextProductCategory.Delete(productCategoryViewModel.Id, user);
            }

            return Json(new[] { productCategoryViewModel }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region Product Action Methods
        public ActionResult EditingProductPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(contextProduct.GetAll().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingProductPopup_Create([DataSourceRequest] DataSourceRequest request, ProductManagerViewModel productViewModel)
        {
            if (productViewModel != null && ModelState.IsValid)
            {
                contextProduct.AddEdit(productViewModel, user);
            }

            return Json(new[] { productViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingProductPopup_Update([DataSourceRequest] DataSourceRequest request, ProductManagerViewModel productViewModel)
        {
            if (productViewModel != null && ModelState.IsValid)
            {
                contextProduct.AddEdit(productViewModel, user);
            }

            return Json(new[] { productViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingProductPopup_Destroy([DataSourceRequest] DataSourceRequest request, ProductManagerViewModel productViewModel)
        {
            if (productViewModel != null)
            {
                contextProduct.Delete(productViewModel.Id, user);
            }

            return Json(new[] { productViewModel }.ToDataSourceResult(request, ModelState));
        }
        #endregion

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