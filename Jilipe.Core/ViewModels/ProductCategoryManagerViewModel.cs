using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.Core.ViewModels
{
    public class ProductCategoryManagerViewModel : ProductCategory
    {
        [DisplayName("Products")]
        public int ProductsCount { get; set; }
    }
}
