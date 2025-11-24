using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace CRUD
{
    public partial class Product : ObservableObject
    {
        static public int productCount;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        private int localId;

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
            localId = productCount;
            name = "";
            price = 0;
            category = "";
            creationDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        public Product(string NameInp, double priceInp, string CatInp)
        {
            productCount++;
            localId = productCount;
            name = NameInp;
            price = priceInp;
            category = CatInp;
            creationDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
    }
}