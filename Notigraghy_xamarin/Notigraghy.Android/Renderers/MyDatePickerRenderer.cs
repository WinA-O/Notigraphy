using Android.Content;
using Notigraghy.Droid.Renderers;
using Notigraghy.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyDatePicker), typeof(MyDatePickerRenderer))]
namespace Notigraghy.Droid.Renderers
{
    public class MyDatePickerRenderer : DatePickerRenderer
    {
        public MyDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //적용이 잘 안됨
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
        }
    }
}