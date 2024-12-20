using ExpensesManager.Data.Extensions;
using ExpensesManager.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data.Repositories
{
    public class ExpensesRepository
    {
        private readonly IDbContextFactory<ExpensesManagerDbContext> _dbContextFactory;

        public ExpensesRepository(IDbContextFactory<ExpensesManagerDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<ExpensesExtendedDto?> GetByIdAsync(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var entity = await context.Expenses.SingleOrDefaultAsync(x => x.Id == id);

            if (entity is not null)
            {
                // Explicit loading
                await context.Entry(entity).Reference(x => x.User).LoadAsync();

                return entity.ToExpensesDto();
            }

            return null;
        }

        public async Task<List<ExpensesExtendedDto>> GetAllAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            
            // Eager loading
            var entities = context.Expenses
                .AsNoTracking()
                .Include(x => x.User)
                .Select(x => x.ToExpensesDto());

            return await entities.ToListAsync();
        }
    }
}
