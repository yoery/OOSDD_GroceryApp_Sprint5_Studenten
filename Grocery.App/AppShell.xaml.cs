using Grocery.App.Views;

namespace Grocery.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Routes uit Grocery.App.Views
            Routing.RegisterRoute(nameof(GroceryListItemsView), typeof(GroceryListItemsView));
            Routing.RegisterRoute(nameof(ProductView), typeof(ProductView));
            Routing.RegisterRoute(nameof(ChangeColorView), typeof(ChangeColorView));
            Routing.RegisterRoute("Login", typeof(LoginView));
            Routing.RegisterRoute(nameof(BestSellingProductsView), typeof(BestSellingProductsView));
            Routing.RegisterRoute(nameof(BoughtProductsView), typeof(BoughtProductsView));
            Routing.RegisterRoute("categories", typeof(CategoriesView));
            Routing.RegisterRoute("productcategories", typeof(ProductCategoriesView));
        }
    }
}
