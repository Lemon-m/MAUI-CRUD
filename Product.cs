using CommunityToolkit.Mvvm.ComponentModel;

namespace CRUD
{
    public partial class Product : ObservableObject
    {
        static public int productCount;


        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private double price;

        [ObservableProperty]
        private string category;

        [ObservableProperty]
        private string creationDate;

        public Product()
        {
            productCount++;
            id = productCount;
            name = "";
            price = 0;
            category = "";
            creationDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        public Product(string NameInp, double priceInp, string CatInp)
        {
            productCount++;
            id = productCount;
            name = NameInp;
            price = priceInp;
            category = CatInp;
            creationDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
    }
}