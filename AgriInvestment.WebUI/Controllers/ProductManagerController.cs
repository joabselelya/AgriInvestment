using AgriInvestment.Core.Contracts;
using AgriInvestment.Core.Extensions;
using AgriInvestment.Core.Models;
using AgriInvestment.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriInvestment.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        private IRepository<Product> context;
        private IRepository<ProductCategory> contextProductCategory;

        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            this.context = productContext;
            this.contextProductCategory = productCategoryContext;
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();

            foreach (var product in products)
                product.Category = contextProductCategory.Find(product.CategoryId);

            return View(products);
        }

        public ActionResult AddNew()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel
            {
                Product = new Product(),
                ProductCategories = contextProductCategory.Collection()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNew(ProductManagerViewModel productManagerViewModel)
        {
            if (!ModelState.IsValid)
                return View(productManagerViewModel);

            productManagerViewModel.Product.Id = context.Collection().Count() + 1;
            context.Insert(productManagerViewModel.Product);
            context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            Product product = context.Find(Id);

            if (product == null)
                return HttpNotFound();

            ProductManagerViewModel viewModel = new ProductManagerViewModel
            {
                Product = product,
                ProductCategories = contextProductCategory.Collection()
            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Update(ProductManagerViewModel productManagerViewModel, int Id)
        {
            if (!ModelState.IsValid)
                return View(productManagerViewModel);

            context.Update(productManagerViewModel.Product, Id);
            context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
                return HttpNotFound();

            productToDelete.Category = contextProductCategory.Find(productToDelete.CategoryId);
            return View(productToDelete);
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