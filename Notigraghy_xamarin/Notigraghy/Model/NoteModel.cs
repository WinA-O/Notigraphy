using Android.Graphics;
using Notigraghy.PhotoManager;
using System;
using System.IO;
using Xamarin.Forms;

namespace Notigraghy.Model
{
    public class NoteModel : ViewModelBase
    {
        public string ID { get; set; }

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value;
                OnPropertyChanged("Date"); }
        }
        private DateTime _Date;

        public string MainText
        {
            get { return _MainText; }
            set { _MainText = value;
                OnPropertyChanged("MainText"); }
        }
        private string _MainText;

        public byte[] OriginalImage { get; set; }

        public byte[] ThumNail { get; set; }
        //[JsonIgnore]
        public ImageSource ThumNailSource
        {
            get { return _ThumNailSource; }
            set
            {
                _ThumNailSource = value;
                OnPropertyChanged("ThumNailSource");
            }
        }
        private ImageSource _ThumNailSource;

        public NoteModel()
        {
            
        }
    }
}
