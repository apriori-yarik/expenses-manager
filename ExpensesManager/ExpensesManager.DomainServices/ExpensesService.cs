using ExpensesManager.Contracts.Models.Expenses;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Services;
using ExpensesManager.DomainServices.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.DomainServices
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpensesRepository _expensesRepository;

        public ExpensesService(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task<ExpenseExtendedModel?> GetByIdAsync(int id)
        {
            var dto = await _expensesRepository.GetByIdAsync(id);

            return dto?.ToExpenseModel();
        }

        public async Task<List<ExpenseExtendedModel>> GetAllAsync()
        {
            var dtos = await _expensesRepository.GetAllAsync();

            return dtos.ToUserModeWithId().ToList();
        }

        public async Task<ExpenseExtendedModel> CreateAsync(ExpenseModel model)
        {
            var dto = await _expensesRepository.CreateAsync(model.ToExpenseDto());

            return dto.ToExpenseModel();
        }

        public async Task DeleteAsync(int id)
        {
            await _expensesRepository.DeleteAsync(id);
        }

        public async Task<ExpenseExtendedModel?> UpdateAsync(int id, ExpenseModelWithUserId model)
        {
            var dto = await _expensesRepository.UpdateAsync(id, model.ToExpenseDto());

            return dto?.ToExpenseModel();
        }
    }
}
