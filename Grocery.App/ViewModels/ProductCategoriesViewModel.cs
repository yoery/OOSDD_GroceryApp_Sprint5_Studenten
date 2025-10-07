using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class ProductCategoriesViewModel : ObservableObject
    {
        private readonly IProductCategoryService _productCategoryService;

        [ObservableProperty]
        private ObservableCollection<ProductCategory> productCategories;

        private int? _categoryId;

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
            ProductCategories = new ObservableCollection<ProductCategory>(_productCategoryService.GetAllProductCategories());
        }

        public void SetCategoryId(int categoryId)
        {
            _categoryId = categoryId;
            ProductCategories = new ObservableCollection<ProductCategory>(
                _productCategoryService.GetAllProductCategories()
                    .Where(pc => pc.CategoryId == categoryId));
        }

        [RelayCommand]
        private void Refresh()
        {
            if (_categoryId.HasValue)
            {
                ProductCategories = new ObservableCollection<ProductCategory>(
                    _productCategoryService.GetAllProductCategories()
                        .Where(pc => pc.CategoryId == _categoryId.Value));
            }
            else
            {
                ProductCategories = new ObservableCollection<ProductCategory>(_productCategoryService.GetAllProductCategories());
            }
        }

        [RelayCommand]
        private void DeleteProductCategory(ProductCategory productCategory)
        {
            if (productCategory != null)
            {
                _productCategoryService.DeleteProductCategory(productCategory.Id);
                Refresh();
            }
        }
    }
}   