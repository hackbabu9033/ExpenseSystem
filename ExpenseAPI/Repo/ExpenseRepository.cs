using ExpenseAPI.Data;
using ExpenseAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAPI.Repo
{
     // create IExpenseRepository implementation
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseContext _context;

        public ExpenseRepository(ExpenseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense> GetExpense(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task UpdateExpense(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<Expense> DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return null;
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return expense;
        }
    }
}
