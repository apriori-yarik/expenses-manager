using ExpensesManager.Contracts.Models.Expenses;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Services;
using ExpensesManager.DomainServices.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace ExpensesManager.DomainServices
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IConverter _converter;

        public ExpensesService(IExpensesRepository expensesRepository, IConverter converter)
        {
            _expensesRepository = expensesRepository;
            _converter = converter;
        }

        public async Task<ExpenseExtendedModel?> GetByIdAsync(int id)
        {
            var dto = await _expensesRepository.GetByIdAsync(id);

            return dto?.ToExpenseModel();
        }

        public async Task<List<ExpenseExtendedModel>> GetAllAsync()
        {
            var dtos = await _expensesRepository.GetAllAsync();

            return dtos.ToUserModeWithId().ToList();
        }

        public async Task<ExpenseExtendedModel> CreateAsync(ExpenseModel model)
        {
            var dto = await _expensesRepository.CreateAsync(model.ToExpenseDto());

            return dto.ToExpenseModel();
        }

        public async Task DeleteAsync(int id)
        {
            await _expensesRepository.DeleteAsync(id);
        }

        public async Task<ExpenseExtendedModel?> UpdateAsync(int id, ExpenseModelWithUserId model)
        {
            var dto = await _expensesRepository.UpdateAsync(id, model.ToExpenseDto());

            return dto?.ToExpenseModel();
        }

        public async Task<byte[]> ExportPdfAsync(int userId)
        {
            var template = await File.ReadAllTextAsync(Path.Combine("HtmlTemplates", "expensesReport.html"));

            var expenses = await _expensesRepository.GetAllByUserIdAsync(userId);

            var sb = new StringBuilder();

            foreach (var item in expenses)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{item.Name}</td>");
                sb.AppendLine($"<td>{item.ExpenseType.ToString()}</td>");
                sb.AppendLine($"<td>{item.Amount}</td>");
                sb.AppendLine("</tr>");
            };

            template = template.Replace("{{expenses}}", sb.ToString());

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = 
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 10 },
                },
                Objects = 
                {
                    
                    new ObjectSettings()
                    {
                        HtmlContent = template,
                        WebSettings = { DefaultEncoding = "utf-8" },
                    },
                }
            };

            var pdf = _converter.Convert(doc);

            return pdf;
        }
    }
}
