namespace MAUI_CRUD
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));

            Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
        }
    }
}
