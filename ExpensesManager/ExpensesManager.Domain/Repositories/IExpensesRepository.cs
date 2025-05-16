using ExpensesManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Domain.Repositories
{
    public interface IExpensesRepository
    {
        Task<ExpenseExtendedDto> CreateAsync(ExpenseDto dto);
        Task DeleteAsync(int id);
        Task<List<ExpenseExtendedDto>> GetAllAsync();
        Task<List<ExpenseDto>> GetAllByUserIdAsync(int userId);
        Task<ExpenseExtendedDto?> GetByIdAsync(int id);
        Task<ExpenseExtendedDto?> UpdateAsync(int id, ExpenseDtoWithUserId expenseDto);
    }
}
