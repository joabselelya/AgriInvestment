using AgriInvestment.Core.Contracts;
using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriInvestment.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        IRepository<ProductCategory> context;

        public ProductCategoryManagerController(IRepository<ProductCategory> productCategoryContext)
        {
            this.context = productCategoryContext;
        }

        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult AddNew()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult AddNew(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
                return View(productCategory);

            productCategory.Id = context.Collection().Count() + 1;
            context.Insert(productCategory);
            context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);

            if (productCategoryToEdit == null)
                return HttpNotFound();

            return View(productCategoryToEdit);
        }

        [HttpPost]
        public ActionResult Update(ProductCategory productCategory, int Id)
        {
            if (!ModelState.IsValid)
                return View(productCategory);
            
            context.Update(productCategory, Id);
            context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
                return HttpNotFound();

            return View(productCategoryToDelete);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            context.Delete(Id);
            context.Commit();

            return RedirectToAction("Index");
        }
    }
}