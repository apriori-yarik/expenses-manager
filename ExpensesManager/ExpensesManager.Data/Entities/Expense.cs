using ExpensesManager.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data.Entities
{
    public class Expense : BaseEntityWithId
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public ExpenseType ExpenseType { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<Limit> Limits { get; set; }
    }
}
