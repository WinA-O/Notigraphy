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
        public int DeviceWidth
        {
            get { return _DeviceWidth; }
            set { _DeviceWidth = value; OnPropertyChanged("DeviceWidth"); }
        }
        private int _DeviceWidth; 

        public int FeedHeight
        {
            get { return _FeedHeight; }
            set { _FeedHeight = value; OnPropertyChanged("FeedHeight"); }
        }
        private int _FeedHeight;

        public DateTime EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; OnPropertyChanged("EditDate"); }
        }
        private DateTime _EditDate;

        public string DefaltTextColor
        {
            get { return _DefaltTextColor; }
            set { _DefaltTextColor = value; OnPropertyChanged("DefaltTextColor"); }
        }
        private string _DefaltTextColor;

        public string Feedthumnail
        {
            get { return _Feedthumnail; }
            set { _Feedthumnail = value; OnPropertyChanged("Feedthumnail"); }
        }
        private string _Feedthumnail;

        public ObservableCollection<MemoList> MemoList
        {
            get { return _MemoList; }
            set { _MemoList = value; OnPropertyChanged("MemoList"); }
        }
        private ObservableCollection<MemoList> _MemoList;
        
        public ScrollView AbsoluteLayoutView;







        //Constructor
        private MainView View {get;set;}
        public MainViewModel(MainView view )
        {
            this.View = view;
            InitializeCommands();            
            MemoList = new ObservableCollection<MemoList>();
            AbsoluteLayoutView = this.View.FindByName<ScrollView>("AbsoluteLayoutView");
            MakeNoteList();
            InitializeUI();
        }

        private void MakeNoteList()
        {
            MemoList memoList1 = new MemoList()
            {
                ID = "1",
                Date = DateTime.Now,
                ThumNail = "YellowStar.png",
                Note = "Json으로 관리하자"
            };

            MemoList memoList2 = new MemoList()
            {
                ID = "2",
                Date = DateTime.Now,
                ThumNail = "YellowStar.png",
                Note = "Json으로 관리하자s"
            };

            MemoList memoList3 = new MemoList()
            {
                ID = "3",
                Date = DateTime.Now,
                ThumNail = "YellowStar.png",
                Note = "Json으로 관리하자d"
            };

            this.MemoList.Add(memoList1);
            this.MemoList.Add(memoList2);
            this.MemoList.Add(memoList3);
        }

        public void InitializeUI()
        {
            EditDate = DateTime.Now;
            DeviceWidth = GlobalResources.ScreenWidth/4;
            FeedHeight = DeviceWidth + 40;
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

        //피드 선택 시
        private void ExecuteTabFeed(object obj)
        {
            //this.View.Navigation.PushAsync(new CreateNoteView());
        }


        //리스트 선택 시
        private void ExecuteTabList(object obj)
        {
            //this.View.Navigation.PushAsync(new MemoListView());
        }

        //글쓰기 선택 시
        private void ExecuteTabCreateNote(object obj)
        {
            this.View.Navigation.PushAsync(new CreateNoteView());
        }
    }

    public class MemoList
    {
        public string ID { get; set; }
        public DateTime Date { get; set; }
        public string ThumNail { get; set; }
        //public byte[] ThumNail { get; set; }
        //[JsonIgnore]
        //public ImageSource ThumNailSource
        //{
        //    get
        //    {
        //        if (ThumNail != null)
        //        {
        //            return Xamarin.Forms.ImageSource.FromStream(() =>
        //            {
        //                return new MemoryStream(ThumNail);
        //            });
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //}
        public string Note { get; set; }
    }
}
