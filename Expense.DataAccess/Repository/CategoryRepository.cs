using Expense.DataAccess.Data;
using Expense.DataAccess.Repository.IRepository;
using Expense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.DataAccess.Repository {
    public class CategoryRepository : ICategoryRepository {

        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) {
            _context = context;
        }

        public void CreateCategory(Category category) {
            _context.Categoryset.Add(category);
            _context.SaveChanges();
            return;
        }

        public void DeleteCategory(Category category) {
            _context.Categoryset.Remove(category);
            _context.SaveChanges();
            return;
        }

        public IEnumerable<Category> GetAllCategories() {
            return _context.Categoryset;
        }

        public Category? GetCategoryById(int? id) {
            return _context.Categoryset.FirstOrDefault(c => c.Id == id!);
        }

        public void UpdateCategory(Category category) {
            _context.Categoryset.Update(category);
            _context.SaveChanges();
            return;
        }
    }
}
