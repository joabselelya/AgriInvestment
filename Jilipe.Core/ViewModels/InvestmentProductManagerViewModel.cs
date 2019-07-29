using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.ViewModels
{
    public class InvestmentProductManagerViewModel : InvestmentProduct
    {
        [DisplayName("Category")]
        public string ProductCategoryName { get; set; }

        [DisplayName("Investments")]
        public int InvestmentsCount { get; set; }

        public IEnumerable<InvestmentCategory> InvestmentCategories { get; set; }

        public InvestmentProductManagerViewModel()
        {
            InvestmentCategory = new InvestmentCategory();
        }
    }
}
