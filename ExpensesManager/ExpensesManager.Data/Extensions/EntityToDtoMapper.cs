using ExpensesManager.Data.Entities;
using ExpensesManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data.Extensions
{
    public static class EntityToDtoMapper
    {
        public static UserDtoWithId ToUserDto(this User user)
        {
            return new UserDtoWithId()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
            };
        }

        public static IEnumerable<UserDtoWithId> ToUserDto(this List<User> users)
        {
            foreach (var user in users)
            {
                yield return user.ToUserDto();
            }
        }
    }
}
