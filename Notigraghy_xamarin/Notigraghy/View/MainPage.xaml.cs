using Xamarin.Forms;

namespace Notigraghy.View
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel;
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = ViewModel = new MainViewModel(this);
           
        }
    }
}
