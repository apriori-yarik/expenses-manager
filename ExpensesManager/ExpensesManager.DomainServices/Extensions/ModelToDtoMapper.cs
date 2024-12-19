using ExpensesManager.Contracts.Models.Users;
using ExpensesManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.DomainServices.Extensions
{
    public static class ModelToDtoMapper
    {
        public static UserDto ToUserDto(this UserModel model)
        {
            return new UserDto()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
            };
        }
    }
}
