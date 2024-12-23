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

        public static ExpenseDto ToExpenseDto(this ExpenseModel expenseModel)
        {
            return new ExpenseDto()
            {
                Name = expenseModel.Name,
                ExpenseType = expenseModel.ExpenseType,
                Amount = expenseModel.Amount
            };
        }

        public static ExpenseDtoWithUserId ToExpenseDto(this ExpenseModelWithUserId model)
        {
            return new ExpenseDtoWithUserId()
            {
                Name = model.Name,
                ExpenseType = model.ExpenseType,
                Amount = model.Amount,
                UserId = model.UserId
            };
        }
    }
}
