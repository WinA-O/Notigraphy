using Android.Graphics;
using Android.Widget;
using Notigraghy.Droid.Renderers;
using Notigraghy.Renderers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using droid = Android;

[assembly: Dependency(typeof(MyButtonRenderer))]
[assembly: ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace Notigraghy.Droid.Renderers
{
    public class MyButtonRenderer : ButtonRenderer
    {
        public droid.Views.ViewGroup AndroidView { get; set; }
        public static ContentView _content = new ContentView();
        public MyButtonRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.Click += Control_Click;
            }
        }

        void Control_Click(object sender, System.EventArgs e)
        {
            // The Forms Page that you want to create image

            //var formsView = new FormsPage();
            //var formsView = new PinchToZoomContainer2();
                        
            var formsView = _content;

            var test = formsView.Content.FindByName<Image>("TestImage");
            //Converting forms page to native view
            AndroidView = FormsToNativeDroid.ConvertFormsToNative(test, new Rectangle(0, 0, 200, 400));

            // Converting View to BitMap
            var bitmap = ConvertViewToBitMap(AndroidView);

            // Saving image in mobile local storage
            SaveImage(bitmap);
        }

        private Bitmap ConvertViewToBitMap(droid.Views.ViewGroup view)
        {

            Bitmap bitmap = Bitmap.CreateBitmap(200, 400, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bitmap);
            canvas.DrawColor(droid.Graphics.Color.White);
            view.Draw(canvas);
            return bitmap;
        }

        private void SaveImage(Bitmap bitmap)
        {
            var sdCardPath = droid.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var fileName = System.IO.Path.Combine(sdCardPath, DateTime.Now.ToFileTime() + ".png");
            using (var os = new FileStream(fileName, FileMode.CreateNew))
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 95, os);
            }

            Toast.MakeText(AndroidView.Context, "Image saved Successfully..!  at " + fileName, ToastLength.Long).Show();
        }

        

       

        public void ShareImage(ContentView img)
        {
            _content = img;
        }
    }
}