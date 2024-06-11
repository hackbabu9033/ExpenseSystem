using ExpenseAPI.Model;

namespace ExpenseAPI.Repo
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> GetExpense(int id);
        Task UpdateExpense(Expense expense);
        Task AddExpense(Expense expense);
        Task<Expense> DeleteExpense(int id);
    }
}
