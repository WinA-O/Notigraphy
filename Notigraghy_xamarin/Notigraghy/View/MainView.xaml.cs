using Xamarin.Forms;

namespace Notigraghy.View
{
    public partial class MainView : ContentPage
    {
        public MainViewModel ViewModel;
        public MainView()
        {
            InitializeComponent();
            this.BindingContext = ViewModel = new MainViewModel();

            
        }
    }
}
