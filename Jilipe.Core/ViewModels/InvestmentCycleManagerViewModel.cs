using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.ViewModels
{
    public class InvestmentCycleManagerViewModel : InvestmentCycle
    {
        public string ProductName { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
