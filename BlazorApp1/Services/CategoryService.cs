using BlazorApp1.Data;
using BlazorApp1.Models;
using BlazorApp1.Pages;

namespace BlazorApp1.Services
{
    public class CategoryService
    {
        private readonly ExpenseTrackerContext _context;
        
        public CategoryService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
