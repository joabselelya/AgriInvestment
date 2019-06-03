using AgriInvestment.Core.Extensions;
using AgriInvestment.Core.Models;
using AgriInvestment.Core.ViewModels;
using Jilipe.Core.Models;
using Jilipe.DataAccess.SQLDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriInvestment.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        private ProductDataSource context;
        private ProductCategoryDataSource contextProductCategory;
        private User user;

        public ProductManagerController()
        {
            this.context = new ProductDataSource();
            this.contextProductCategory = new ProductCategoryDataSource();
            this.user = new User();
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductManagerViewModel> products = context.GetAllVm();

            return View(products);
        }

        public ActionResult AddNew()
        {
            Product product = new Product();
            ViewBag.ProductCategories = contextProductCategory.GetAll();

            return View(product);
        }

        [HttpPost]
        public ActionResult AddNew(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            context.AddEdit(product, user);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            Product product = context.GetById(Id);

            if (product == null)
                return HttpNotFound();

            ProductManagerViewModel viewModel = new ProductManagerViewModel
            {
                //Product = product,
                ProductCategories = contextProductCategory.GetAll()
            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Update(ProductManagerViewModel productManagerViewModel, int Id)
        {
            if (!ModelState.IsValid)
                return View(productManagerViewModel);

            context.AddEdit(productManagerViewModel, user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Product productToDelete = context.GetById(Id);

            if (productToDelete == null)
                return HttpNotFound();

            //productToDelete.Category = contextProductCategory.Find(productToDelete.CategoryId);
            return View(productToDelete);
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