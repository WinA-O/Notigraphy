using Android.Content;
using Android.Net;
using Notigraghy.Model;

namespace Notigraghy
{
    public class MainEventRouter
    {
        public delegate void AfterCreateNote(NoteModel NewNote);
        public event AfterCreateNote OnAfterCreateNote;
        public void AfterCreateNoteEventFire(NoteModel NewNote)
        {
            if (OnAfterCreateNote != null)
            {
                OnAfterCreateNote(NewNote);
            }
        }

        public delegate void PhotoSeleced(byte[] byteArray);
        public event PhotoSeleced OnPhotoSeleced;
        public void PhotoSelecedEventFire(byte[] byteArray)
        {
            if (OnPhotoSeleced != null)
            {
                OnPhotoSeleced(byteArray);
            }
        }


        private static MainEventRouter instance { get; set; }
        private static object mutex = new object();
        public static MainEventRouter Instance
        {
            get
            {
                lock (mutex)
                {
                    if (instance == null)
                    {
                        instance = new MainEventRouter();
                    }
                }
                return instance;
            }
        }
    }
}
