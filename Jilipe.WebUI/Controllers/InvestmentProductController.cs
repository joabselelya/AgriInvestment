using AgriInvestment.Core.ViewModels;
using Jilipe.Core.Models;
using Jilipe.DataAccess.SQLDapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jilipe.WebUI.Controllers
{
    public class InvestmentProductController : Controller
    {
        private InvestmentCategoryDataSource contextInvestmentCategory;
        private InvestmentProductDataSource contextInvestmentProduct;
        private const string IMAGE_PREFIX = "prod";
        private const string IMAGE_PATH = "~/Images/Products/";
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
        public ActionResult EditingInvestmentProductPopup_Update([DataSourceRequest] DataSourceRequest request, InvestmentProductManagerViewModel investmentProductViewModel, IEnumerable<HttpPostedFileBase> productPhoto)
        {
            if (investmentProductViewModel != null && ModelState.IsValid)
            {
                HttpPostedFileBase image = (HttpPostedFileBase)TempData["UploadedProductPhoto"];

                if (image != null){
                    var physicalPath = Path.Combine(Server.MapPath(IMAGE_PATH), investmentProductViewModel.ImageFile);

                    image.SaveAs(physicalPath);
                }

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
                var physicalPath = Path.Combine(Server.MapPath(IMAGE_PATH), investmentProductViewModel.ImageFile);

                if (System.IO.File.Exists(physicalPath))
                {
                    System.IO.File.Delete(physicalPath);
                }
                contextInvestmentProduct.Delete(investmentProductViewModel.Id, user);
            }

            return Json(new[] { investmentProductViewModel }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        public ActionResult ResetTempData()
        {
            TempData["UploadedProductPhoto"] = null;
            return Content("");
        }

        public ActionResult AsyncSavePhoto(IEnumerable<HttpPostedFileBase> productPhoto)
        {
            if (productPhoto != null)
            {
                TempData["UploadedProductPhoto"] = productPhoto.First();
            }

            return Content("");
        }

        public ActionResult AsyncRemovePhoto(string[] fileNames)
        {
            if (fileNames != null)
            {
                TempData["UploadedProductPhoto"] = null;
            }

            return Content("");
        }
    }
}