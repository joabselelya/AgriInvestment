using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.Models
{
    public class InvestmentCycle : BaseEntity
    {
        [DisplayName("Starting From")]
        [Required(ErrorMessage = "Investment commencement date is required")]
        public DateTime FromDate { get; set; }

        [DisplayName("Product")]
        //[ForeignKey("ProductId")]
        [Required(ErrorMessage = "Investment product is required")]
        public int ProductId { get; set; }
        //public Product Product { get; set; }

        [DisplayName("Target Amount (KES)")]
        [Range(50000, 99999999, ErrorMessage = ("Target investment amount should be between KES. 50,000 and 99,999,999"))]
        [Required(ErrorMessage = "Target investement amount is required")]
        public decimal TargetAmount { get; set; }

        [DisplayName("Min. Amount (KES)")]
        [Required(ErrorMessage = "Minimum investment amount is required")]
        public decimal MinimumAmount { get; set; }

        [DisplayName("Max. Amount (KES)")]
        [Required(ErrorMessage = "Maximum investment amount is required")]
        public decimal MaximumAmount { get; set; }
    }
}
