﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.Models
{
    public class Product : BaseEntity
    {
        [StringLength(20)]
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        [Required(ErrorMessage = "Product description is required")]
        public string Description { get; set; }

        [DisplayName("Investment Months")]
        [Range(1, 120, ErrorMessage = "Investment months can only be between 1 and 120 months")]
        [Required(ErrorMessage = ("Investment months is required"))]
        public byte InvestmentMonths { get; set; }

        [DisplayName("Category")]
        [ForeignKey("Category")]
        [Required(ErrorMessage = "Product category is required")]
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public ICollection<InvestmentCycle> InvestmentCycles { get; set; }
    }
}
