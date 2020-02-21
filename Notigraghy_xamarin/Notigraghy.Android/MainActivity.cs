using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Notigraghy.Droid.Photo;
using Notigraghy.Interface;
using Xamarin.Forms;
[assembly: Dependency(typeof(Notigraghy.Droid.MainActivity))]
namespace Notigraghy.Droid
{
    [Activity(Label = "Notigraghy", Icon = "@drawable/YellowStar", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAndroid
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

        public void GalleryOpen()
        {
            var intent = new Intent(Forms.Context, typeof(GalleryActivity));
            Forms.Context.StartActivity(intent);
        }

        public void ShowToastMessage(string message)
        {
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}