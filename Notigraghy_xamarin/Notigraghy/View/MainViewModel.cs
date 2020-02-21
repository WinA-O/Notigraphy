using Notigraghy.Model;
using System;
using System.Linq;
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

        //메인 뷰에서 리스트를 관리하기로 한다
        public NoteListModel MyNoteInDevice { get; set; }

        //Constructor
        public MainViewModel()
        {
            //이곳에 진입 전에 디바이스에 저장된 노트정보를 가져와서 셋해줘야 함
            MyNoteInDevice = new NoteListModel();
            MakeNoteList();

            InitializeCommands();

            //BodyView = new FeedView(MemoList);

            MainEventRouter.Instance.OnAfterCreateNote += OnAfterCreateNote;
        }

        private void OnAfterCreateNote(NoteModel NewNote)
        {
            MyNoteInDevice.NoteList.Add(NewNote);
            MyNoteInDevice.NoteList = MyNoteInDevice.NoteList.OrderByDescending(p => p.Date).ToList();
            BodyView = new FeedView(MyNoteInDevice);
        }

        //하드코딩
        private void MakeNoteList()
        {
            //var memoList1 = new NoteModel()
            //{
            //    ID = "1",
            //    Date = DateTime.Now.AddDays(-1),
            //    ThumNail = "test1.jpg",
            //    MainText = "이건 사실 하드코딩 덩어리지만 어쩔수없죠 빨리 만들어 보는게 중요하지 않을까용\r\n그래더 주영님이 잘 도와주셔서 넘나 수월할 수 있는것이얌"
            //};

            //var memoList2 = new NoteModel()
            //{
            //    ID = "2",
            //    Date = DateTime.Now.AddDays(-2),
            //    ThumNail = "test2.jpg",
            //    MainText = "이건 사실 하드코딩 덩어리지만 어쩔수없죠 빨리 만들어 보는게 중요하지 않을까용\r\n그래더 주영님이 잘 도와주셔서 넘나 수월할 수 있는것이얌"
            //};

            //var memoList3 = new NoteModel()
            //{
            //    ID = "3",
            //    Date = DateTime.Now.AddDays(-3),
            //    ThumNail = "test3.jpg",
            //    MainText = "이건 사실 하드코딩 덩어리지만 어쩔수없죠 빨리 만들어 보는게 중요하지 않을까용\r\n그래더 주영님이 잘 도와주셔서 넘나 수월할 수 있는것이얌"
            //};

            //var memoList4 = new NoteModel()
            //{
            //    ID = "4",
            //    Date = DateTime.Now.AddDays(-4),
            //    ThumNail = "test4.jpg",
            //    MainText = "이건 사실 하드코딩 덩어리지만 어쩔수없죠 빨리 만들어 보는게 중요하지 않을까용\r\n그래더 주영님이 잘 도와주셔서 넘나 수월할 수 있는것이얌"
            //};

            //var memoList5 = new NoteModel()
            //{
            //    ID = "5",
            //    Date = DateTime.Now.AddDays(-5),
            //    ThumNail = "test5.jpg",
            //    MainText = "이건 사실 하드코딩 덩어리지만 어쩔수없죠 빨리 만들어 보는게 중요하지 않을까용\r\n그래더 주영님이 잘 도와주셔서 넘나 수월할 수 있는것이얌"
            //};

            //var memoList6 = new NoteModel()
            //{
            //    ID = "6",
            //    Date = DateTime.Now.AddDays(-6),
            //    ThumNail = "test6.jpg",
            //    MainText = "이건 사실 하드코딩 덩어리지만 어쩔수없죠 빨리 만들어 보는게 중요하지 않을까용\r\n그래더 주영님이 잘 도와주셔서 넘나 수월할 수 있는것이얌"
            //};

            //this.MyNoteInDevice.NoteList.Add(memoList1);
            //this.MyNoteInDevice.NoteList.Add(memoList2);
            //this.MyNoteInDevice.NoteList.Add(memoList3);
            //this.MyNoteInDevice.NoteList.Add(memoList4);
            //this.MyNoteInDevice.NoteList.Add(memoList5);
            //this.MyNoteInDevice.NoteList.Add(memoList6);

            //BodyView = new FeedView(MyNoteInDevice);
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
            BodyView = new FeedView(MyNoteInDevice);
        }

        //리스트 선택 시
        private void ExecuteTabList(object obj)
        {
            BodyView = new NoteListView(MyNoteInDevice);
        }

        //글쓰기 선택 시
        private void ExecuteTabCreateNote(object obj)
        {
            BodyView = new CreateNoteView();
        }
    }
}
