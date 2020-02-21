using Notigraghy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Notigraghy.View
{
    public class FeedViewModel : ViewModelBase
    {
        //Binding Properties//////////////////////////////
        public double DeviceWidth
        {
            get { return _DeviceWidth; }
            set { _DeviceWidth = value; OnPropertyChanged("DeviceWidth"); }
        }
        private double _DeviceWidth;

        public double FeedHeight
        {
            get { return _FeedHeight; }
            set { _FeedHeight = value; OnPropertyChanged("FeedHeight"); }
        }
        private double _FeedHeight;

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
        public FeedViewModel(NoteListModel noteList)
        {
            //최초 1회, 혹은 리스트에 변동이 생겼을 때만 리스트를 생성 혹은 엎어치도록
            this.MemoList = noteList;
            InitializeUI();
        }

        public void InitializeUI()
        {
            EditDate = DateTime.Now;
            DeviceWidth = GlobalResources.ScreenWidth / (GlobalResources.ScreenWidth / GlobalResources.Dpi);
            FeedHeight = DeviceWidth + 40;
        }
    }

  
}
