using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Models {
    public class User {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Enter name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Enter email")]
        [EmailAddress(ErrorMessage ="Email is invalid")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Enter password")]
        public string Password { get; set; }

    }
}
