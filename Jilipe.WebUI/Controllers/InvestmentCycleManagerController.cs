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
    public class InvestmentCycleManagerController : Controller
    {
        private investmentCycleDataSource context;
        private ProductDataSource contextProduct;
        private User user;

        public InvestmentCycleManagerController()
        {
            this.context = new investmentCycleDataSource();
            this.contextProduct = new ProductDataSource();
            this.user = new User();
        }

        // GET: InvestmentCycle
        public ActionResult Index()
        {
            List<InvestmentCycleManagerViewModel> investmentCycles = context.GetAllVm();

            //foreach (var investmentCycle in investmentCycles)
            //    investmentCycle.Product = contextProduct.Find(investmentCycle.ProductId);

            return View(investmentCycles);
        }

        public ActionResult AddNew()
        {
            InvestmentCycleManagerViewModel viewModel = new InvestmentCycleManagerViewModel
            {
                //InvestmentCycle = new InvestmentCycle(),
                Products = contextProduct.GetAll()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNew(InvestmentCycleManagerViewModel investmentCycleViewModel)
        {
            if (!ModelState.IsValid)
                return View(investmentCycleViewModel);

            //investmentCycleViewModel.InvestmentCycle.Id = context.Collection().Count() + 1;
            //context.Insert(investmentCycleViewModel.InvestmentCycle);
            context.AddEdit(investmentCycleViewModel, user);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            InvestmentCycle InvestmentCycle = context.GetById(Id);

            if (InvestmentCycle == null)
                return HttpNotFound();

            InvestmentCycleManagerViewModel viewModel = new InvestmentCycleManagerViewModel
            {
                //InvestmentCycle = InvestmentCycle,
                Products = contextProduct.GetAll()
            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Update(InvestmentCycleManagerViewModel investmentCycleViewModel, int Id)
        {
            if (!ModelState.IsValid)
                return View(investmentCycleViewModel);

            //context.Update(investmentCycleViewModel.InvestmentCycle, Id);
            context.AddEdit(investmentCycleViewModel, user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            InvestmentCycle InvestmentCycleToDelete = context.GetById(Id);

            if (InvestmentCycleToDelete == null)
                return HttpNotFound();

            //InvestmentCycleToDelete.Product = contextProduct.Find(InvestmentCycleToDelete.ProductId);
            return View(InvestmentCycleToDelete);
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