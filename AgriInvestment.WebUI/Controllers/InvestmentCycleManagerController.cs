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
    public class InvestmentCycleManagerController : Controller
    {
        private IRepository<InvestmentCycle> context;
        private IRepository<Product> contextProduct;

        public InvestmentCycleManagerController(IRepository<InvestmentCycle> InvestmentCycleContext, IRepository<Product> ProductContext)
        {
            this.context = InvestmentCycleContext;
            this.contextProduct = ProductContext;
        }

        // GET: InvestmentCycle
        public ActionResult Index()
        {
            List<InvestmentCycle> investmentCycles = context.Collection().ToList();

            foreach (var investmentCycle in investmentCycles)
                investmentCycle.Product = contextProduct.Find(investmentCycle.ProductId);

            return View(investmentCycles);
        }

        public ActionResult AddNew()
        {
            InvestmentCycleManagerViewModel viewModel = new InvestmentCycleManagerViewModel
            {
                InvestmentCycle = new InvestmentCycle(),
                Products = contextProduct.Collection()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNew(InvestmentCycleManagerViewModel investmentCycleViewModel)
        {
            if (!ModelState.IsValid)
                return View(investmentCycleViewModel);

            investmentCycleViewModel.InvestmentCycle.Id = context.Collection().Count() + 1;
            context.Insert(investmentCycleViewModel.InvestmentCycle);
            context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            InvestmentCycle InvestmentCycle = context.Find(Id);

            if (InvestmentCycle == null)
                return HttpNotFound();

            InvestmentCycleManagerViewModel viewModel = new InvestmentCycleManagerViewModel
            {
                InvestmentCycle = InvestmentCycle,
                Products = contextProduct.Collection()
            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Update(InvestmentCycleManagerViewModel investmentCycleViewModel, int Id)
        {
            if (!ModelState.IsValid)
                return View(investmentCycleViewModel);

            context.Update(investmentCycleViewModel.InvestmentCycle, Id);
            context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            InvestmentCycle InvestmentCycleToDelete = context.Find(Id);

            if (InvestmentCycleToDelete == null)
                return HttpNotFound();

            InvestmentCycleToDelete.Product = contextProduct.Find(InvestmentCycleToDelete.ProductId);
            return View(InvestmentCycleToDelete);
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