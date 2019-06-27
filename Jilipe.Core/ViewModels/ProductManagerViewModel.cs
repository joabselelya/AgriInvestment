using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.ViewModels
{
    public class ProductManagerViewModel : Product
    {
        [DisplayName("Category")]
        public string ProductCategoryName { get; set; }
        [DisplayName("Investments")]
        public int InvestmentsCount { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
