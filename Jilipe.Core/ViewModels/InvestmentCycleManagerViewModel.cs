using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.ViewModels
{
    public class InvestmentCycleManagerViewModel : InvestmentCycle
    {
        public string ProductName { get; set; }
        public DateTime MaturityDate { get; set; }
        [DisplayName("Months")]
        public byte InvestmentPeriod { get; set; }
        public InvestmentProduct InvestmentProduct { get; set; }
        public IEnumerable<InvestmentProduct> InvestmentProducts { get; set; }
    }
}
