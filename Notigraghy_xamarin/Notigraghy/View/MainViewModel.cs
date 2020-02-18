using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Notigraghy.Model;
using Xamarin.Forms;

namespace Notigraghy.View
{
    public class MainViewModel : ViewModelBase
    {
        //Binding Properties//////////////////////////////

        public ContentView BodyView
        {
            get { return _BodyView; }
            set { _BodyView = value; this.OnPropertyChanged("BodyView"); }
        }
        private ContentView _BodyView;

        //Constructor
        public MainViewModel()
        {
            BodyView = new FeedView();
            InitializeCommands();
        }

        //Commands/////////////////////////////////////////

        public Command TabFeedCommand { get; set; }
        public Command TabListCommand { get; set; }
        public Command TabCreateNoteCommand { get; set; }

        private void InitializeCommands()
        {
            TabFeedCommand = new Command(ExecuteTabFeed);
            TabListCommand = new Command(ExecuteTabList);
            TabCreateNoteCommand = new Command(ExecuteTabCreateNote);
;        }


        //TODO : wina BodyView를 계속 생성해주면 어떤 결과가 나타날까? clear나 dispose등을 해줘야 하는지?
        //피드 선택 시
        private void ExecuteTabFeed(object obj)
        {
            BodyView = new FeedView();
        }

        //리스트 선택 시
        private void ExecuteTabList(object obj)
        {
            BodyView = new NoteListView();
        }

        //글쓰기 선택 시
        private void ExecuteTabCreateNote(object obj)
        {
            BodyView = new CreateNoteView();
        }
    }
}
