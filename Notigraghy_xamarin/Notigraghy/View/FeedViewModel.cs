using Notigraghy.Model;
using System;
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

        public ObservableCollection<MemoList> MemoList
        {
            get { return _MemoList; }
            set { _MemoList = value; OnPropertyChanged("MemoList"); }
        }
        private ObservableCollection<MemoList> _MemoList;

        public double ViewWidth;

        //Constructor
        public FeedViewModel()
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
                Note = "Json으로 관리하자"
            };

            MemoList memoList2 = new MemoList()
            {
                ID = "2",
                Date = DateTime.Now,
                ThumNail = "TempImg2.png",
                Note = "Json으로 관리하자s"
            };

            MemoList memoList3 = new MemoList()
            {
                ID = "3",
                Date = DateTime.Now,
                ThumNail = "TempImg3.png",
                Note = "Json으로 관리하자d"
            };

            this.MemoList.Add(memoList1);
            this.MemoList.Add(memoList2);
            this.MemoList.Add(memoList3);
            this.MemoList.Add(memoList1);
            this.MemoList.Add(memoList2);
            this.MemoList.Add(memoList3);
        }

        public void InitializeUI()
        {
            EditDate = DateTime.Now;
            DeviceWidth = GlobalResources.ScreenWidth / (GlobalResources.ScreenWidth / GlobalResources.Dpi);
            FeedHeight = DeviceWidth + 40;
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
