using Android.Content;
using Notigraghy.Droid.Renderers;
using Notigraghy.Renderers;
using Xamarin.Forms;


[assembly: ExportRenderer(typeof(MyWebview), typeof(MyWebviewRenderer))]
namespace Notigraghy.Droid.Renderers
{
    public class MyWebviewRenderer : Xamarin.Forms.Platform.Android.WebViewRenderer
    {
        public MyWebviewRenderer(Context context) : base(context)
        {

        }
    }
}