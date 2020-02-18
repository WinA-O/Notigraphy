using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Notigraghy.Renderers
{
    public class MySlider : Xamarin.Forms.Slider
    {
        // Events for external use (for example XAML)
        public event EventHandler TouchDown;
        public event EventHandler TouchUp;
        public event EventHandler TouchProgress;


        // Events called by renderers
        public EventHandler TouchDownEvent;
        public EventHandler TouchUpEvent;
        public EventHandler TouchProgressChanged;

        public MySlider()
        {
            TouchDownEvent = delegate
            {
                TouchDown?.Invoke(this, EventArgs.Empty);
            };
            TouchUpEvent = delegate
            {
                TouchUp?.Invoke(this, EventArgs.Empty);

            };
            TouchProgressChanged = delegate
            {
                TouchProgress?.Invoke(this, EventArgs.Empty);
            };
            TouchUp = delegate
            {
                TouchProgress?.Invoke(this, EventArgs.Empty);
            };

        }


        public static readonly BindableProperty MaxColorProperty = BindableProperty.Create(nameof(MaxColor), typeof(Color), typeof(MySlider), Color.Default);

        public Color MaxColor
        {
            get { return (Color)GetValue(MaxColorProperty); }
            set { SetValue(MaxColorProperty, value); }
        }

        public static readonly BindableProperty MinColorProperty = BindableProperty.Create(nameof(MinColor),
            typeof(Color), typeof(MySlider), Color.Default);

        public Color MinColor
        {
            get { return (Color)GetValue(MinColorProperty); }
            set { SetValue(MinColorProperty, value); }
        }

        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor),
            typeof(Color), typeof(MySlider), Color.Default);

        public Color ThumbColor
        {
            get { return (Color)GetValue(ThumbColorProperty); }
            set { SetValue(ThumbColorProperty, value); }
        }

        public static readonly BindableProperty ThumbImageProperty = BindableProperty.Create(nameof(ThumbImage),
              typeof(string), typeof(MySlider), string.Empty);

        public string ThumbImage
        {
            get { return (string)GetValue(ThumbImageProperty); }
            set { SetValue(ThumbImageProperty, value); }
        }

    }
}
