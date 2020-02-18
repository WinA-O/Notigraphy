using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Notigraghy.Droid
{
    [Activity(Label = "Notigraghy", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            GlobalResources.ScreenHeight = (double)Resources.DisplayMetrics.HeightPixels;
            GlobalResources.ScreenWidth = (double)Resources.DisplayMetrics.WidthPixels;
            GlobalResources.Dpi = (double)Resources.DisplayMetrics.DensityDpi;

            LoadApplication(new App());
        }
    }
}