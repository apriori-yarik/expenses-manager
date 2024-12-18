using ExpensesManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task<UserDtoWithId> CreateAsync(UserDto dto);
        Task DeleteAsync(int id);
        Task<List<UserDtoWithId>> GetAllAsync();
        Task<UserDtoWithId?> GetByIdAsync(int id);
        Task<UserDtoWithId?> UpdateAsync(int id, UserDto dto);
    }
}
