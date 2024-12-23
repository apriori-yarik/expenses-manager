using ExpensesManager.Contracts.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Domain.Services
{
    public interface IUsersService
    {
        Task<UserModelWithId> CreateAsync(UserModel model);
        Task DeleteAsync(int id);
        Task<List<UserModelWithId>> GetAllAsync();
        Task<UserModelWithId?> GetByIdAsync(int id);
        Task<UserModelWithId?> UpdateAsync(int id, UserModel model);
    }
}
