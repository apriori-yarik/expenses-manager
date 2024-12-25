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
        Task<ExpenseExtendedModel> CreateAsync(ExpenseModel model);
        Task DeleteAsync(int id);
        Task<byte[]> ExportPdfAsync(int userId);
        Task<List<ExpenseExtendedModel>> GetAllAsync();
        Task<ExpenseExtendedModel?> GetByIdAsync(int id);
        Task<ExpenseExtendedModel?> UpdateAsync(int id, ExpenseModelWithUserId model);
    }
}
