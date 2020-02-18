using Xamarin.Forms;

namespace Notigraghy.Renderers
{
    public class MyButton : Button
    {
        // //Button with no padding

        // //IsChecked Property
        public string IsChecked
        {
            get { return (string)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        // public bool IsChecked { get; set; }
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
                                                         propertyName: "IsChecked",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(MyButton),
                                                         defaultValue: "false",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: IsCheckedPropertyChanged);

        private static void IsCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //var control = (TWButton)bindable;
            //control.Text = newValue.ToString();
        }
    }
}
