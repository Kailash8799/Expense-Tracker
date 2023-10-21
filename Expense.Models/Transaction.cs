using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Models {
    public class Transaction {
        [Key]
        public int Id { get; set; }

        public int  UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Range(1, int.MaxValue,ErrorMessage = "Amount should be grater than 1")]
        public int Amount { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
