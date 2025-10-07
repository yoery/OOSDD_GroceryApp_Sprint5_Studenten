using Grocery.App.ViewModels;

namespace Grocery.App.Views
{
    public partial class ProductCategoriesView : ContentPage
    {
        public ProductCategoriesView(ProductCategoriesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnNavigatedTo(Microsoft.Maui.Controls.NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            var query = Shell.Current.CurrentState.Location?.Query;
            var categoryIdStr = string.Empty;
            if (!string.IsNullOrEmpty(query))
            {
                var queryParams = System.Web.HttpUtility.ParseQueryString(query);
                categoryIdStr = queryParams["categoryId"];
            }

            if (!string.IsNullOrEmpty(categoryIdStr) &&
                int.TryParse(categoryIdStr, out var categoryId) &&
                BindingContext is ProductCategoriesViewModel vm)
            {
                vm.SetCategoryId(categoryId);
            }
        }
    }
}