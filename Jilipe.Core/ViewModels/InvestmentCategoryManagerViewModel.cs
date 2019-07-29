using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.Core.ViewModels
{
    public class InvestmentCategoryManagerViewModel : InvestmentCategory
    {
        [DisplayName("Products")]
        public int InvestmentProductsCount { get; set; }
    }
}
