using ExpensesManager.Data.Extensions;
using ExpensesManager.Domain.Dtos;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContextFactory<ExpensesManagerDbContext> _contextFactory;

        public UsersRepository(IDbContextFactory<ExpensesManagerDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<UserDtoWithId?> GetByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var entity = await context.Users.FindAsync(id);

            return entity?.ToUserDto();
        }

        public async Task<List<UserDtoWithId>> GetAllAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var entities = await context.Users.AsNoTracking().ToListAsync();

            return entities.ToUserDto().ToList();
        }

        public async Task<UserDtoWithId> CreateAsync(UserDto dto)
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var entity = await context.AddAsync(dto.ToUser());
            await context.SaveChangesAsync();

            return entity.Entity.ToUserDto();
        }

        public async Task<UserDtoWithId?> UpdateAsync(int id, UserDto dto)
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            if (!await context.Users.AnyAsync(x => x.Id == id))
            {
                return null;
            }

            var user = dto.ToUser();
            user.Id = id;

            var entity = context.Users.Update(user);
            await context.SaveChangesAsync();

            return entity.Entity.ToUserDto();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            await context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
