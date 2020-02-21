using Notigraghy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notigraghy.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedView : ContentView
	{
		public FeedView (NoteListModel noteList)
		{
			InitializeComponent ();
            this.BindingContext = new FeedViewModel(noteList);
        }
	}
}