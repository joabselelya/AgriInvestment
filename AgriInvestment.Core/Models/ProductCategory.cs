using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        [StringLength(20)]
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Product category name is required!")]
        public string Name { get; set; }

        [DisplayName("Category Description")]
        [Required(ErrorMessage = "Product category Description is required")]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
