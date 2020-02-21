using Android.Net;
using Notigraghy.Interface;
using Notigraghy.Model;
using Notigraghy.PhotoManager;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Notigraghy.View
{
    public class CreateNoteViewModel : ViewModelBase
    {
        //Constructor//////////////////////////////////////
        public CreateNoteViewModel()
        { 
            TempNoteModel = new NoteModel();
            InitializeCommands();

            MainEventRouter.Instance.OnPhotoSeleced += OnPhotoSeleced;
        }


        //Binding Properties//////////////////////////////
        public bool IsPhotoLoaded
        {
            get { return _IsPhotoLoaded; }
            set { _IsPhotoLoaded = value; this.OnPropertyChanged("IsPhotoLoaded"); }
        }
        private bool _IsPhotoLoaded = false;

        public NoteModel TempNoteModel //얘를 뿌려야지?
        {
            get { return _TempNoteModel; }
            set { _TempNoteModel = value; this.OnPropertyChanged("TempNoteModel"); }
        }
        private NoteModel _TempNoteModel;



        NoteListModel MyNoteList { get; set; }

        //Function///////////////////////////////////////////
        private void OnPhotoSeleced(byte[] bytePhotoArray)
        {
            MainEventRouter.Instance.OnPhotoSeleced -= OnPhotoSeleced;
            
            var thumnail = CreateThumnail(bytePhotoArray, 100);
            TempNoteModel.ThumNail = thumnail;
            //TODO : wina 썸네일 부분 수정 후 재적용 필요
            //TempNoteModel.ThumNailSource = ImageSource.FromStream(() => new MemoryStream(TempNoteModel.ThumNail));
            TempNoteModel.ThumNailSource = ImageSource.FromStream(() => new MemoryStream(bytePhotoArray));

        }

        public byte[] CreateThumnail(byte[] org, int width)
        {
            //TODO : wina width, height 값 때문에 일그러지는 현상이 있는 것 같다, PhotoResizer.ResizeImage 수정해야함
            var thumnail = PhotoResizer.ResizeImage(org, width, width, 1);
            return thumnail;
        }

        //Commands/////////////////////////////////////////

        public Command SaveNoteCommand { get; set; }
        public Command AddPhotoCommand { get; set; }

        private void InitializeCommands()
        {
            SaveNoteCommand = new Command(ExecuteSaveNote);
            AddPhotoCommand = new Command(ExecuteAddPhoto);
        }


        //노트 저장 버튼 선택 시
        private void ExecuteSaveNote()
        {
            TempNoteModel.Date = DateTime.Now;
            if (TempNoteModel.MainText != null)
            {
                Application.Current.MainPage.DisplayAlert("알림", "저장완료!", "OK"); //토스트 메세지로 수정하기
                MainEventRouter.Instance.AfterCreateNoteEventFire(TempNoteModel);
            }
        }

        //사진 추가 버튼 선택 시
        private void ExecuteAddPhoto()
        {
            IsPhotoLoaded = true;
            DependencyService.Get<IAndroid>().GalleryOpen();
        }
    }
}
