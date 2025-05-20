using ExpensesManager.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data.Entities
{
    public class Limit : BaseEntityWithId
    {
        public string Name { get; set; }
        public decimal MaxMoney { get; set; }
        public LimitType LimitType { get; set; }
        public DateTime CreatedAt { get; set; }

        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }
    }
}
