using ExpensesManager.Contracts.Models.Users;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Services;
using ExpensesManager.DomainServices.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.DomainServices
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserModelWithId?> GetByIdAsync(int id)
        {
            var dto = await _usersRepository.GetByIdAsync(id);

            return dto?.ToUserModelWithId();
        }

        public async Task<List<UserModelWithId>> GetAllAsync()
        {
            var dtos = await _usersRepository.GetAllAsync();

            return dtos.ToUserModeWithId().ToList();
        }

        public async Task<UserModelWithId> CreateAsync(UserModel model)
        {
            var dto = await _usersRepository.CreateAsync(model.ToUserDto());

            return dto.ToUserModelWithId();
        }

        public async Task<UserModelWithId?> UpdateAsync(int id, UserModel model)
        {
            var dto = await _usersRepository.UpdateAsync(id, model.ToUserDto());

            return dto?.ToUserModelWithId();
        }

        public async Task DeleteAsync(int id)
        {
            await _usersRepository.DeleteAsync(id);
        }
    }
}
