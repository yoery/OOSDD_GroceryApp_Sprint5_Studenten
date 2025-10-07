using Grocery.App.ViewModels;
using Grocery.Core.Models;

namespace Grocery.App.Views;

public partial class BoughtProductsView : ContentPage
{
    private readonly BoughtProductsViewModel _viewModel;

    public BoughtProductsView(BoughtProductsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        _viewModel = viewModel;
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            Grocery.Core.Models.Product? product = picker.SelectedItem as Grocery.Core.Models.Product;
            if (product != null)
            {
                _viewModel.NewSelectedProduct(product);
            }
        }
    }
}