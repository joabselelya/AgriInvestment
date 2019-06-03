using AgriInvestment.Core.Models;
using Jilipe.Core.Models;
using Jilipe.DataAccess.SQLDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriInvestment.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        ProductCategoryDataSource context;
        User user;
        
        public ProductCategoryManagerController()
        {
            this.context = new ProductCategoryDataSource();
            user = new User();
            user.Id = 1;
        }

        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.GetAll();
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

            context.AddEdit(productCategory, user);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            ProductCategory productCategoryToEdit = context.GetById(Id);

            if (productCategoryToEdit == null)
                return HttpNotFound();

            return View(productCategoryToEdit);
        }

        [HttpPost]
        public ActionResult Update(ProductCategory productCategory, int Id)
        {
            if (!ModelState.IsValid)
                return View(productCategory);
            
            context.AddEdit(productCategory, user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            ProductCategory productCategoryToDelete = context.GetById(Id);

            if (productCategoryToDelete == null)
                return HttpNotFound();

            return View(productCategoryToDelete);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            context.Delete(Id, user);

            return RedirectToAction("Index");
        }
    }
}