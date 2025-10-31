namespace MAUI_CRUD;

public partial class EditPage : ContentPage
{
    public EditPage(EditPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    private void PriceEntry_Unfocused(object sender, FocusEventArgs e)
    {
        if (double.TryParse(((Entry)sender).Text, out double value))
        {
            ((Entry)sender).Text = value.ToString("F2");
        }
    }
}