using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD;
using System.Collections.ObjectModel;

namespace MAUI_CRUD.ViewModels
{
    public partial class AddPageViewModel : ObservableObject
    {
        private readonly ObservableCollection<Product> products;

        public AddPageViewModel(ObservableCollection<Product> products)
        {
            this.products = products;
        }

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string category;

        [ObservableProperty]
        string price;

        [RelayCommand]
        async Task BackToMain()
        {
            Shell.Current.Navigation.PopAsync(true);
        }

        [RelayCommand]
        async Task AddProduct()
        {
            if(double.TryParse(price, out double value))
            {
                products.Add(new Product(name, value, category));
            }
            Shell.Current.Navigation.PopAsync(true);
        }
    }
}
