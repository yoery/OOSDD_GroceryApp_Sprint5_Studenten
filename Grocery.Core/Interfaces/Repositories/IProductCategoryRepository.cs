using System.Collections.Generic;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetAll();
        ProductCategory? GetById(int id);
        void Add(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
        void Delete(int id);
    }
}