namespace Shop.UIForms.View_Models
{
    using Common.Models;
    using Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Products> products;
        private bool isRefreshing;

        public ObservableCollection<Products> Products
        {
            get => this.products;
            set => this.SetValue(ref this.products, value);
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            this.IsRefreshing = true;

            var response = await this.apiService.GetListAsync<Products>(
                "https://shopguzmo.azurewebsites.net",
                "/api",
                "/Products");

            this.IsRefreshing = false;
            if (!response.IsSuccsess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accep");
                return;
            }

            var myProducts = (List<Products>)response.Result;
            this.Products = new ObservableCollection<Products>(myProducts);
        }
    }
}
