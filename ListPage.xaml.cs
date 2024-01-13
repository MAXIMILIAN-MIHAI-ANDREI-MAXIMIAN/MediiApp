namespace MediiApp;
using MediiApp.Models;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)
        this.BindingContext)
        {
            BindingContext = new Product()
        });
    }

    async void OnDeleteItemClicked(object sender, EventArgs e)
    {
        if (listView.SelectedItem is Product selectedProduct)
        {
            bool confirm = await DisplayAlert("Confirm", "Are you sure you want to delete this item?", "Yes", "No");
            if (confirm)
            {
                await App.Database.DeleteProductAsync(selectedProduct);
                var shopl = (ShopList)BindingContext;
                listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
            }
        }
        else
        {
            await DisplayAlert("No Selection", "Please select an item to delete.", "OK");
        }
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ShopList)BindingContext;
        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }

}