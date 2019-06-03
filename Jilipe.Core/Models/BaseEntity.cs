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

        [DisplayName("Created On")]
        public DateTimeOffset CreatedAt { get; set; }

        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
