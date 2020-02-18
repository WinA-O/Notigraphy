using Android.Content;
using Notigraghy.Droid.Renderers;
using Notigraghy.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(MyEditor), typeof(MyEditorRenderer))]
namespace Notigraghy.Droid.Renderers
{
    public class MyEditorRenderer : EditorRenderer
    {
        public MyEditorRenderer(Context context) : base(context) { }
        //public static void Init() { }


        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
        }
    }
}