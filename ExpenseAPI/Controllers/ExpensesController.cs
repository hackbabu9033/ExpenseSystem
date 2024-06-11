using ExpenseAPI.Model;
using ExpenseAPI.Model.Enum;
using ExpenseAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAPI.Controllers
{
    // create Expense Controller
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpensesController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
        {
            return new OkObjectResult(await _expenseRepository.GetExpenses());
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _expenseRepository.GetExpense(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, Expense expense)
        {
            // get expense by id
            var expenseToUpdate = await _expenseRepository.GetExpense(id);
            // if not found, return NotFound
            if (expenseToUpdate == null)
            {
                return NotFound();
            }
            // update the expense
            expenseToUpdate.Title = expense.Title;  
            expenseToUpdate.Amount = expense.Amount;
            expenseToUpdate.Date = expense.Date;
            expenseToUpdate.Category = expense.Category;
            await _expenseRepository.UpdateExpense(expenseToUpdate);

            return new OkObjectResult(expenseToUpdate);
        }

        // POST: api/Expenses
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            // when adding a new expense, the Title should not be empty
            if (string.IsNullOrEmpty(expense.Title))
            {
                return BadRequest("Title should not be empty");
            }

            // when adding a new expense, the Amount should be greater than 0
            if (expense.Amount <= 0)
            {
                return BadRequest("Amount should be greater than 0");
            }
            // when adding a new expense, the Date cannot be older than 1 year
            if (expense.Date < DateTime.Now.AddYears(-1))
            {
                return BadRequest("Date cannot be older than 1 year");
            }
            // when adding a new expense, the Category should be valid
            if (!Enum.IsDefined(typeof(Category), expense.Category))
            {
                return BadRequest("Category should be valid");
            }

            await _expenseRepository.AddExpense(expense);

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expense>> DeleteExpense(int id)
        {
            var expense = await _expenseRepository.DeleteExpense(id);
            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }
    }

   
}
