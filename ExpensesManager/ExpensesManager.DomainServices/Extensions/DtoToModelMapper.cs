using ExpensesManager.Contracts.Models.Users;
using ExpensesManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.DomainServices.Extensions
{
    public static class DtoToModelMapper
    {
        public static UserModelWithId ToUserModelWithId(this UserDtoWithId dto)
        {
            return new UserModelWithId()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
            };
        }

        public static IEnumerable<UserModelWithId> ToUserModeWithId(this List<UserDtoWithId> dto)
        {
            foreach (var user in dto)
            {
                yield return user.ToUserModelWithId();
            }
        }
    }
}
