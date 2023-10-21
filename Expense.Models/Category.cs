using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Models {
    public class Category {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Enter title")]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Enter type")]
        [MaxLength(20)]
        public string Type { get; set; } = "Expense";

    }
}
