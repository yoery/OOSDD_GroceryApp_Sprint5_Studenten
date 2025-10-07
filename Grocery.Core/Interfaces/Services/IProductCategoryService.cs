using System.Collections.Generic;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAllProductCategories();
        ProductCategory? GetProductCategoryById(int id);
        void CreateProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(int id);
    }
}