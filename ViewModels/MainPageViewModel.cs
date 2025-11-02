using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD;
using MAUI_CRUD.Popups;
using System.Collections.ObjectModel;


namespace MAUI_CRUD.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private bool dataLoaded;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        [ObservableProperty]
        private bool leSecretVisible;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          

        private int leSecretCounter;

        public Grid AlertOverlay { get; set; }

        public MainPageViewModel(ObservableCollection<Product> products, IPopupService PopupService)
        {
            dataLoaded = false;
            LeSecretVisible = false;
            leSecretCounter = 0;
            this.products = products;
        }
        public void OnPageAppearing()
        {
            if (dataLoaded) return;

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "produkty.csv");

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                if (lines.Length > 1)
                {
                    int lastID = 1;

                    for (int i = 1; i < lines.Length; i++)
                    {
                        var cols = lines[i].Split(';');

                        if (cols.Length < 5)
                        {
                            continue;
                        }

                        if (!int.TryParse(cols[0], out int id)) continue;

                        if (!double.TryParse(cols[2], out double priceCSVTemp)) continue;
                        
                        products.Add
                        (
                            new Product
                            {
                                Id = id,
                                Name = cols[1],
                                Price = priceCSVTemp,
                                Category = cols[3],
                                CreationDate = cols[4]
                            }
                        );
                        

                        if (id > lastID) lastID = id;
                    }

                    Product.productCount = lastID;

                    dataLoaded = true;
                }
                else
                {
                    Product.productCount = 0;
                    dataLoaded = true;
                }
            }
        }

        [RelayCommand]
        async Task EnterAddPage()
        {
            await Shell.Current.GoToAsync(nameof(AddPage), true);
        }

        [RelayCommand]
        async Task EnterEditPage(int Id)
        {
            await Shell.Current.GoToAsync($"{nameof(EditPage)}?Id={Id}", true);
        }

        [RelayCommand]
        async Task DeleteProduct(int Id)
        {
            var toDelete = products.SingleOrDefault(p => p.Id == Id);
            products.Remove(toDelete);
        }

        [RelayCommand]
        async Task ExportCSV()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "produkty.csv");

            File.WriteAllText(filePath, "ID;Nazwa;Cena;Kategoria;Data utworzenia" + Environment.NewLine);
            using (StreamWriter writer = File.AppendText(filePath))
            {
                foreach (Product pdt in products)
                {
                    writer.WriteLine($"{pdt.Id};{pdt.Name};{pdt.Price};{pdt.Category};{pdt.CreationDate}");
                }
            }
            var toast = Toast.Make("Wyeksportowano produkty!", ToastDuration.Short, 14);
            await toast.Show();
        }

        [RelayCommand]
        async Task LeSecret()
        {
            leSecretCounter++;
            if(leSecretCounter == 5)
            {
                LeSecretVisible = true;
                var toast = Toast.Make("Komunis", ToastDuration.Short, 14);
                await toast.Show();
            }
        }

        [RelayCommand]
        async Task Secret()
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                SystemStyleAlertView.Show(AlertOverlay, "Adrian", "explain our friend group", "zandbi.jpg");
            });
        }
    }
}