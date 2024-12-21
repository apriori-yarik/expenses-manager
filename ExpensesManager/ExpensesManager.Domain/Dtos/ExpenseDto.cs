﻿using ExpensesManager.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Domain.Dtos
{
    public class ExpenseDto
    {
        public string Name { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public decimal Amount { get; set; }
    }
}