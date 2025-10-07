using System.Collections.Generic;
using System.Linq;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> _productCategories = new();

        public IEnumerable<ProductCategory> GetAll() => _productCategories;

        public ProductCategory? GetById(int id) => _productCategories.FirstOrDefault(pc => pc.Id == id);

        public void Add(ProductCategory productCategory)
        {
            _productCategories.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            var existing = GetById(productCategory.Id);
            if (existing != null)
            {
                existing.ProductId = productCategory.ProductId;
                existing.CategoryId = productCategory.CategoryId;
            }
        }

        public void Delete(int id)
        {
            var productCategory = GetById(id);
            if (productCategory != null)
            {
                _productCategories.Remove(productCategory);
            }
        }
    }
}