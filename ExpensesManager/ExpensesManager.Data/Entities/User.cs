using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data.Entities
{
    public class User : BaseEntityWithId
    {
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
