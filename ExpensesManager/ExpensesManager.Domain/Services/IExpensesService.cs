using ExpensesManager.Contracts.Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Domain.Services
{
    public interface IExpensesService
    {
        Task<List<ExpenseExtendedModel>> GetAllAsync();
        Task<ExpenseExtendedModel?> GetByIdAsync(int id);
    }
}
