using Microsoft.Maui.Controls;

namespace MAUI_CRUD.Popups;
public class SystemStyleAlertView : ContentView
{
    public SystemStyleAlertView(string header, string message, string? imageSource = null)
    {
        BackgroundColor = Colors.Transparent;

        var alertStack = new VerticalStackLayout
        {
            BackgroundColor = Application.Current.RequestedTheme == AppTheme.Dark
            ? Color.FromArgb("#2C2C2E")
            : Colors.White,
            WidthRequest = 300,
            Padding = new Thickness(20),
            Spacing = 6,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        alertStack.Children.Add(new Label
        {
            Text = header,
            FontAttributes = FontAttributes.Bold,
            FontSize = 16,
            TextColor = Application.Current.RequestedTheme == AppTheme.Dark ? Colors.White : Colors.Black,
            HorizontalOptions = LayoutOptions.Start
        });

        if (!string.IsNullOrEmpty(imageSource))
        {
            alertStack.Children.Add(new Image
            {
                Source = imageSource,
                WidthRequest = 90,
                HorizontalOptions = LayoutOptions.Start
            });
        }

        alertStack.Children.Add(new Label
        {
            Text = message,
            FontSize = 14,

            TextColor = Application.Current.RequestedTheme == AppTheme.Dark ? Colors.White : Colors.Black,
            HorizontalOptions = LayoutOptions.Start
        });

        var okButton = new Button
        {
            Text = "OK",
            BackgroundColor = Colors.Transparent,
            TextColor = Application.Current.RequestedTheme == AppTheme.Dark ? Colors.White : Colors.Black,
            HorizontalOptions = LayoutOptions.End,
            Padding = new Thickness(0),
            Margin = new Thickness(0, 10, 0, 0)
        };

        okButton.Clicked += (_, __) =>
        {
            if (Parent is Grid parentGrid)
            {
                parentGrid.Children.Clear();
                parentGrid.IsVisible = false;
            }
        };

        alertStack.Children.Add(okButton);

        Content = alertStack;
    }

    public static void Show(Grid overlayGrid, string header, string message, string? imageSource = null)
    {
        overlayGrid.Children.Clear();
        overlayGrid.Children.Add(new SystemStyleAlertView(header, message, imageSource));
        overlayGrid.IsVisible = true;
    }

    public static void ShowImageAlert(Grid overlayGrid, string header, string message, string? imageSource = null)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            overlayGrid.Children.Clear();
            overlayGrid.Children.Add(new SystemStyleAlertView(header, message, imageSource));
            overlayGrid.IsVisible = true;
        });
    }
}
