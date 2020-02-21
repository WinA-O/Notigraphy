using Notigraghy.PhotoManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Notigraghy.Model
{
    public class NoteListModel : ViewModelBase
    {
        public List<NoteModel> NoteList
        {
            get { return _NoteList; }
            set { _NoteList = value; OnPropertyChanged("NoteList"); }
        }
        private List<NoteModel> _NoteList;

        public NoteListModel()
        {
            NoteList = new List<NoteModel>();
        }

        public virtual NoteModel CreateNote(byte[] thumNail, string mainText)
        {
            var NewNote = new NoteModel()
            {
                ID = DateTime.Now.ToString(),
                Date = DateTime.Now,
                ThumNail = thumNail,
                MainText = mainText
            };
            NoteList.OrderBy(p => p.Date).ToList();
            //NoteList.OrderByDescending(p => p.Date).ToList();
            return NewNote;
        }
    }
}
