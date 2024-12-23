using ExpensesManager.Contracts.Models.Expenses;
using ExpensesManager.Contracts.Models.Users;
using ExpensesManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var user = await _expensesService.GetByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _expensesService.GetAllAsync();

            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _expensesService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] ExpenseModelWithUserId model)
        {
            var user = await _expensesService.UpdateAsync(id, model);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ExpenseModel model)
        {
            var user = await _expensesService.CreateAsync(model);

            return Ok(user);
        }
    }
}
