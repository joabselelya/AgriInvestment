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
        [DisplayName("Name")]
        [Required(ErrorMessage = "Product category name is required!")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Product category description is required")]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
