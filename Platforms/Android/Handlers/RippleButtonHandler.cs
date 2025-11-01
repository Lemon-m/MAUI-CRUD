//Shoutout ChatGPT for fixing ripple effects on buttons with images

#if ANDROID
using Android.Content;
using Android.Graphics.Drawables;
using Google.Android.Material.Button;
using Microsoft.Maui.Handlers;

namespace MAUI_CRUD.Platforms.Android.Handlers;

public class RippleButtonHandler : ButtonHandler
{
    protected override MaterialButton CreatePlatformView()
    {
        var button = base.CreatePlatformView();

        var cornerRadius = (float)(VirtualView?.CornerRadius ?? 0) * button.Resources.DisplayMetrics.Density;

        var mask = new GradientDrawable();
        mask.SetCornerRadius(cornerRadius);
        mask.SetColor(global::Android.Graphics.Color.White);

        var rippleColor = global::Android.Graphics.Color.ParseColor("#33FFFFFF");

        var rippleDrawable = new RippleDrawable(
            global::Android.Content.Res.ColorStateList.ValueOf(rippleColor),
            null,
            mask
        );

        button.Foreground = rippleDrawable;

        return button;
    }
}
#endif
