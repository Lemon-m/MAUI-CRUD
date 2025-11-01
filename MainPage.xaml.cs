using MAUI_CRUD.ViewModels;
using CRUD;
//using StoreKit;
using System.Net.Sockets;
using System.Collections.ObjectModel;

namespace MAUI_CRUD
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();

            vm.AlertOverlay = AlertOverlay;

            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is MainPageViewModel vm)
            {
                vm.OnPageAppearing();
            }
        }
    }
}
