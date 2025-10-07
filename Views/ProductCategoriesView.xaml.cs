using OOSDD_GroceryApp_Sprint5_Studenten.ViewModels;

namespace OOSDD_GroceryApp_Sprint5_Studenten.Views
{
    [QueryProperty(nameof(CategoryId), "categoryId")]
    public partial class ProductCategoriesView : ContentPage
    {
        public int CategoryId
        {
            set
            {
                if (BindingContext is ProductCategoriesViewModel vm)
                {
                    vm.SetCategoryId(value);
                }
            }
        }

        public ProductCategoriesView(ProductCategoriesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}