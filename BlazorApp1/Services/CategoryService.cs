using BlazorApp1.Data;
using BlazorApp1.Models;
using BlazorApp1.Pages;
using Microsoft.EntityFrameworkCore;

namespace BlazerApp1.Services
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
        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        //To Update the records of a particluar category
        public Category UpdateCategoryDetails(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }

        //Get the details of a particular category
        public Category GetCategoryData(int id)
        {
            try
            {
                Category? category = _context.Categories.Find(id);
                if (category != null)
                {
                    return category;
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

        //To Delete the record of a particular category
        public void DeleteCategory(int id)
        {
            try
            {
                Category? category = _context.Categories.Find(id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
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

