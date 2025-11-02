//Shoutout ChatGPT for this too

using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MAUI_CRUD.Popups;
public class SystemStyleAlertView : ContentView
{

    public SystemStyleAlertView(string header, string message, string? imageSource = null)
    {

        BackgroundColor = Color.FromArgb("#80000000");

        var alertStack = new VerticalStackLayout
        {
            BackgroundColor = Application.Current.RequestedTheme == AppTheme.Dark ? Color.FromArgb("#FF424242") : Colors.White,
            WidthRequest = 300,
            Padding = new Thickness(20),
            Spacing = 6,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Opacity = 0
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
                WidthRequest = 180,
                HorizontalOptions = LayoutOptions.Start
            });
        }

        alertStack.Children.Add(new Label
        {
            Text = message,
            FontSize = 14,
            TextColor = Color.FromArgb("#FFB3B3B3"),
            HorizontalOptions = LayoutOptions.Start
        });

        var okButton = new Button
        {
            Text = "OK",
            BackgroundColor = Colors.Transparent,
            TextColor = Application.Current.RequestedTheme == AppTheme.Dark ? Colors.White : Colors.Black,
            HorizontalOptions = LayoutOptions.End,
            Padding = new Thickness(0),
            Margin = new Thickness(0, 10, 0, 0),
            CharacterSpacing = 1
        };

        okButton.Clicked += async (_, __) =>
        {
            await alertStack.FadeTo(0, 100);
            if (Parent is Grid parentGrid)
            {
                parentGrid.Children.Clear();
                parentGrid.IsVisible = false;
            }
        };

        alertStack.Children.Add(okButton);

        Content = alertStack;

        alertStack.FadeTo(1, 100);
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
