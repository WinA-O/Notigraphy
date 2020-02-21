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

        public NoteListModel MemoList
        {
            get { return _MemoList; }
            set { _MemoList = value; OnPropertyChanged("MemoList"); }
        }
        private NoteListModel _MemoList;

        public double ViewWidth;

        //Constructor
        public NoteListViewModel(NoteListModel noteList)
        {
            this.MemoList = noteList;
            InitializeUI();
        }

        //GlobalResources.ScreenWidth/GlobalResources.Dpi => 약2.5배 나옴, 계산맞는건지??
        public void InitializeUI()
        {
            EditDate = DateTime.Now;
            ListRowHeight = (GlobalResources.ScreenWidth / (GlobalResources.ScreenWidth / GlobalResources.Dpi)/4);
        }
    }
}
