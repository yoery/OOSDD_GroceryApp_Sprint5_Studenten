using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.ViewModels;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly ICategoryService _categoryService;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = new ObservableCollection<Category>(_categoryService.GetAllCategories());
        }

        [RelayCommand]
        private void Refresh()
        {
            Categories = new ObservableCollection<Category>(_categoryService.GetAllCategories());
        }

        [RelayCommand]
        private void DeleteCategory(Category category)
        {
            if (category != null)
            {
                _categoryService.DeleteCategory(category.Id);
                Refresh();
            }
        }

        [RelayCommand]
        private async Task OpenProductCategoriesAsync(Category category)
        {
            if (category != null)
            {
                await Shell.Current.GoToAsync($"productcategories?categoryId={category.Id}");
            }
        }
    }
}