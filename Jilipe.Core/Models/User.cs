using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.Core.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage ="First Name is required!")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage ="Surname is required!")]
        public string Surname { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
