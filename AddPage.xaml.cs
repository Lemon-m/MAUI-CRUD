using MAUI_CRUD.ViewModels;

namespace MAUI_CRUD
{
	public partial class AddPage : ContentPage
	{
        public AddPage(AddPageViewModel vm)
		{
            InitializeComponent();

			BindingContext = vm;
        }

		private void PriceEntry_Unfocused(object sender, FocusEventArgs e)
		{
			if(double.TryParse(((Entry)sender).Text, out double value))
			{
                ((Entry)sender).Text = value.ToString("F2");
            }
		}
	}
}