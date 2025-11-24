using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD;
using System.Collections.ObjectModel;

namespace MAUI_CRUD
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class EditPageViewModel : ObservableObject
    {
        private readonly ObservableCollection<Product> products;
        public EditPageViewModel(ObservableCollection<Product> products)
        {
            this.products = products;
        }

        private Product ogProduct;

        [ObservableProperty]
        private Product product;

        [ObservableProperty]
        private int id;

        [RelayCommand]
        async Task BackToMain()
        {
            Shell.Current.Navigation.PopAsync(true);
        }

        partial void OnIdChanged(int value)
        {
            ogProduct = products.SingleOrDefault(p => p.Id == value);

            if (ogProduct != null)
            {
                Product = new Product
                {
                    Id = ogProduct.Id,
                    LocalId = ogProduct.LocalId,
                    Name = ogProduct.Name,
                    Price = ogProduct.Price,
                    Category = ogProduct.Category,
                    CreationDate = ogProduct.CreationDate
                };
                Product.productCount--;
            }
        }

        [RelayCommand]
        async Task EditProduct()
        {
            if (ogProduct != null && product != null)
            {
                ogProduct.Name = product.Name;
                ogProduct.Price = product.Price;
                ogProduct.Category = product.Category;
            }

            Shell.Current.Navigation.PopAsync(true);
        }
    }
}
