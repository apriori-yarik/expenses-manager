using ExpensesManager.Contracts.Enums;
using ExpensesManager.Contracts.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Contracts.Models.Expenses
{
    public class ExpenseExtendedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public UserModelWithId? User { get; set; }
    }
}
