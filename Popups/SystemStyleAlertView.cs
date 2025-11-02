//Shoutout ChatGPT for this too

using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace MAUI_CRUD.Popups;
public class SystemStyleAlertView : ContentView
{
    private readonly VerticalStackLayout alertStack;

    public SystemStyleAlertView(string header, string message, string? imageSource = null)
    {
        InputTransparent = false;
        IsVisible = true;
        Opacity = 0;

        alertStack = new VerticalStackLayout
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
            await Task.WhenAll(
                this.FadeTo(0, 150, Easing.CubicIn),
                alertStack.FadeTo(0, 150, Easing.CubicIn)
            );

            if (Parent is Grid parentGrid)
            {
                parentGrid.Children.Clear();
                parentGrid.IsVisible = false;
            }
        };

        alertStack.Children.Add(okButton);

        Content = alertStack;

    }

    protected override async void OnParentSet()
    {
        base.OnParentSet();
        if (Parent != null)
        {
            await Task.WhenAll(this.FadeTo(1, 150, Easing.CubicIn), alertStack.FadeTo(1, 150, Easing.CubicIn));
        }
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
