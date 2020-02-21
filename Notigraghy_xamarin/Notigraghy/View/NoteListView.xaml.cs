using Notigraghy.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notigraghy.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //TODO : wina 얘가 무슨 기능 하는지 찾아보기
	public partial class NoteListView : ContentView
	{
		public NoteListView (NoteListModel NoteList)
		{
			InitializeComponent ();
            this.BindingContext = new NoteListViewModel(NoteList);
        }
	}
}