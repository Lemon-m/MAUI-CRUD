namespace MAUI_CRUD
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public App()
        {
            InitializeComponent();
        }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            Services = serviceProvider;

            MainPage = new AppShell();
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}

        protected override async void OnStart()
        {
            await Shell.Current.GoToAsync("//MainPage");

            base.OnStart();
        }
    }
}