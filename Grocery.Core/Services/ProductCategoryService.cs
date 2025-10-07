using System.Collections.Generic;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return _productCategoryRepository.GetAll();
        }

        public ProductCategory? GetProductCategoryById(int id)
        {
            return _productCategoryRepository.GetById(id);
        }

        public void CreateProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.Add(productCategory);
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.Update(productCategory);
        }

        public void DeleteProductCategory(int id)
        {
            _productCategoryRepository.Delete(id);
        }
    }
}