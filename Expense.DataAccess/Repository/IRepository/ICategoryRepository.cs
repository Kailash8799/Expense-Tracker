using Expense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.DataAccess.Repository.IRepository {
    public interface ICategoryRepository {
        public void CreateCategory(Category category);
        public void UpdateCategory(Category category);
        public IEnumerable<Category> GetAllCategories();
        public void DeleteCategory(Category category);
        public Category? GetCategoryById(int? id);

    }
}
