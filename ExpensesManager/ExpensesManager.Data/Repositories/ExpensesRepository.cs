using ExpensesManager.Data.Extensions;
using ExpensesManager.Domain.Dtos;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ExpensesManager.Data.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly IDbContextFactory<ExpensesManagerDbContext> _dbContextFactory;

        public ExpensesRepository(IDbContextFactory<ExpensesManagerDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<ExpenseExtendedDto?> GetByIdAsync(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var entity = await context.Expenses.SingleOrDefaultAsync(x => x.Id == id);

            if (entity is not null)
            {
                // Explicit loading
                await context.Entry(entity).Reference(x => x.User).LoadAsync();

                return entity.ToExpenseExtendedDto();
            }

            return null;
        }

        public async Task<List<ExpenseExtendedDto>> GetAllAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            
            // Eager loading
            var entities = context.Expenses
                .AsNoTracking()
                .Include(x => x.User)
                .Select(x => x.ToExpenseExtendedDto());

            return await entities.ToListAsync();
        }

        public async Task<ExpenseExtendedDto> CreateAsync(ExpenseDto dto)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var entity = await context.Expenses.AddAsync(dto.ToExpense());
            await context.SaveChangesAsync();

            return entity.Entity.ToExpenseExtendedDto();
        }

        public async Task<ExpenseExtendedDto?> UpdateAsync(int id, ExpenseDtoWithUserId expenseDto)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            if (!await context.Expenses.AnyAsync(x => x.Id == id))
            {
                return null;
            }

            var entity = expenseDto.ToExpense();
            entity.Id = id;

            context.Expenses.Update(entity);
            await context.SaveChangesAsync();

            return entity.ToExpenseExtendedDto();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            await context.Expenses.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<ExpenseDto>> GetAllByUserIdAsync(int userId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var result = await context.Expenses
                .Where(x => x.UserId == userId)
                .Select(x => x.ToExpenseDto())
                .ToListAsync();

            return result;
        }
    }
}
