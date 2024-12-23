using ExpensesManager.Data.Entities;
using ExpensesManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data.Extensions
{
    public static class DtoToEntityMapper
    {
        public static User ToUser(this UserDto userDto)
        {
            return new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                DateOfBirth = userDto.DateOfBirth,
                Email = userDto.Email,
            };
        }

        public static Expense ToExpense(this ExpenseDto expenseDto)
        {
            return new Expense()
            {
                Name = expenseDto.Name,
                Amount = expenseDto.Amount,
                ExpenseType = expenseDto.ExpenseType
            };
        }

        public static Expense ToExpense(this ExpenseDtoWithUserId expenseDto)
        {
            return new Expense()
            {
                Name = expenseDto.Name,
                Amount = expenseDto.Amount,
                ExpenseType = expenseDto.ExpenseType,
                UserId = expenseDto.UserId
            };
        }
    }
}
