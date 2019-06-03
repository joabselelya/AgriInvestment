using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.ViewModels
{
    public class ProductManagerViewModel : Product
    {
        public string ProductCategoryName { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
