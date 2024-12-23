using ExpensesManager.Contracts.Models.Expenses;
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

        public static IEnumerable<UserModelWithId> ToUserModeWithId(this List<UserDtoWithId> dtos)
        {
            foreach (var user in dtos)
            {
                yield return user.ToUserModelWithId();
            }
        }

        public static ExpenseExtendedModel ToExpenseModel(this ExpenseExtendedDto dto)
        {
            return new ExpenseExtendedModel()
            {
                Name = dto.Name,
                Amount = dto.Amount,
                ExpenseType = dto.ExpenseType,
                User = dto.User?.ToUserModelWithId(),
                Id = dto.Id
            };
        }

        public static IEnumerable<ExpenseExtendedModel> ToUserModeWithId(this List<ExpenseExtendedDto> dtos)
        {
            foreach (var expense in dtos)
            {
                yield return expense.ToExpenseModel();
            }
        }
    }
}
