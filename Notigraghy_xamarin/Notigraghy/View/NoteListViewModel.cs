using Notigraghy.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

//TODO : wina 메모는 최대 몇줄까지 보여줄지 협의 후 거기에 맞춰 MemoList의 Row Height 설정하기로
namespace Notigraghy.View
{
    public class NoteListViewModel : ViewModelBase
    {
        //Binding Properties//////////////////////////////
        public double ListRowHeight
        {
            get { return _ListRowHeight; }
            set { _ListRowHeight = value; OnPropertyChanged("ListRowHeight"); }
        }
        private double _ListRowHeight;

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

        public double ViewWidth;

        //Constructor
        public NoteListViewModel()
        {
            MemoList = new ObservableCollection<MemoList>();
            InitializeUI();
            MakeNoteList();
        }

        private void MakeNoteList()
        {
            MemoList memoList1 = new MemoList()
            {
                ID = "1",
                Date = DateTime.Now,
                ThumNail = "TempImg1.png",
                MainText = "Json으로 관리하자\r\n냐하앟긴텍스트가필요합니다 도데체 어떻게 해야할까요 룰루랄랄 열심히 적어보는 것 밖에 없죠잉"
            };

            MemoList memoList2 = new MemoList()
            {
                ID = "2",
                Date = DateTime.Now.AddDays(1),
                ThumNail = "TempImg2.png",
                MainText = "이건 사실 하드코딩 덩어리지만 어쩔수없죠 빨리 만들어 보는게 중요하지 않을까용\r\n그래더 주영님이 잘 도와주셔서 넘나 수월할 수 있는것이얌 호호호"
            };
            //요렇게 텍스트가 길어서 잘려 보이는 경우 5줄만 보여주고 뒤엔 ...으로 대체하는 로직 필요함
            MemoList memoList3 = new MemoList()
            {
                ID = "3",
                Date = DateTime.Now.AddDays(3),
                ThumNail = "TempImg3.png",
                MainText = "Json으로 관리하자 Json으로 관리하자 Json으로 관리하자 Json으로 관리하자Json으로 관리하자 Json으로 관리하자 Json으로 관리하자\r\nJson으로 관리" +
                "Json으로 관리하자Json으로 관리하자Json으로 관리하자\r\nJson으로 관리하자Json으로 관리하자Json으로 관리하자Json으로 관리하자" +
                "Json으로 관리하자Json으로 관리하자Json으로 관리하자Json으로 관리하자\r\nJson으로 관리하자Json으로 관리하자Json으로 관리하자"
            };
            this.MemoList.Add(memoList1);
            this.MemoList.Add(memoList2);
            this.MemoList.Add(memoList3);

            memoList1.Date = memoList1.Date.AddDays(2);
            memoList2.Date = memoList1.Date.AddDays(2);
            memoList3.Date = memoList1.Date.AddDays(2);
            this.MemoList.Add(memoList1);
            this.MemoList.Add(memoList2);
            this.MemoList.Add(memoList3);

            memoList1.Date = memoList1.Date.AddDays(2);
            memoList2.Date = memoList1.Date.AddDays(2);
            memoList3.Date = memoList1.Date.AddDays(2);
            this.MemoList.Add(memoList1);
            this.MemoList.Add(memoList2);
            this.MemoList.Add(memoList3);

            this.MemoList.OrderByDescending(p=>p.Date);
        }

        //GlobalResources.ScreenWidth/GlobalResources.Dpi => 약2.5배 나옴, 계산맞는건지??
        public void InitializeUI()
        {
            EditDate = DateTime.Now;
            ListRowHeight = (GlobalResources.ScreenWidth / (GlobalResources.ScreenWidth / GlobalResources.Dpi)/4);
        }
    }
}
