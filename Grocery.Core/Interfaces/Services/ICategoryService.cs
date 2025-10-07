using System.Collections.Generic;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category? GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}