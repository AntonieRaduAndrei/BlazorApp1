using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class ExpenseService
    {

        private readonly ExpenseTrackerContext _context;

        public ExpenseService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public List<Expense> GetExpenses()
        {
            return _context.Expenses.AsNoTracking().ToList();
        }
        public Expense AddExpense(Expense expense)
        {
            expense.Date = expense.Date.ToUniversalTime();
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return expense;
        }

        //To Update the records of a particluar expense
        public Expense UpdateExpenseDetails(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
            _context.SaveChanges();

            return expense;
        }

        //Get the details of a particular expense
        public Expense GetExpenseData(int id)
        {
            try
            {
                Expense? expense = _context.Expenses.Find(id);
                if (expense != null)
                {
                    return expense;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular expense
        public void DeleteExpense(int id)
        {
            try
            {
                Expense? expense = _context.Expenses.Find(id);
                if (expense != null)
                {
                    _context.Expenses.Remove(expense);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
