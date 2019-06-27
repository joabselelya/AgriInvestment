using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.Core.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        ////public int CreatedBy { get; set; }

        ////[DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
        ////    ApplyFormatInEditMode = true)]
        ////[DisplayName("Created On")]
        ////public DateTime? CreatedOn { get; set; }

        ////public int? ModifiedBy { get; set; }

        ////[DisplayName("Modified On")]
        ////public DateTime? ModifiedOn { get; set; }
    }
}
