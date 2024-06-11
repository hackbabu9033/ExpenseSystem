using ExpenseAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAPI.Data
{
    // create Expense Context
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
    
}
