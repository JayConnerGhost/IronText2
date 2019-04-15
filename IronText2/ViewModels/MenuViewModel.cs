using System;
using System.CodeDom;
using System.Configuration;
using IronText2.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace IronText2.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private readonly MenuModel _model;
        private bool _canCreateNew=true;
        private bool _canClose=true;
        private bool _canSave=false;

        public DelegateCommand FileNewCommand { get; private set; }
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand FileSaveCommand { get; private set; }
        public DelegateCommand FileSaveAsCommand { get; private set; }
      
        public DelegateCommand EditCopyCommand { get; private set; }
        public DelegateCommand EditCutCommand { get; private set; }
        public DelegateCommand EditPasteCommand { get; private set; }
        public DelegateCommand EditSelectAllCommand { get; private set; }


        public MenuViewModel(MenuModel model)
        {
            _model = model;
            FileNewCommand=new DelegateCommand(CreateNewExecute,CanCreateNewExecute).ObservesProperty(()=>CanCreateNew);
            CloseCommand=new DelegateCommand(CloseExecute,CanCloseExecute).ObservesProperty(()=>CanClose);
            FileSaveCommand=new DelegateCommand(SaveExecute,CanSaveExecute).ObservesProperty(()=>CanSave);
            FileSaveAsCommand=new DelegateCommand(SaveAsExecute,CanSaveExecute).ObservesProperty(()=>CanSave);
        }

        private void SaveAsExecute()
        {
            var fileName = String.Empty;
            var text = string.Empty;
            _model.Save(fileName, text);
        }

        private bool CanSaveExecute()
        {
            return _canSave;
        }

        private void SaveExecute()
        {
            var fileName = String.Empty;
            var text = string.Empty;
            _model.Save(fileName, text);
        }

        public bool CanSave
        {
            get
            {
                bool canSave = _canSave;
                return canSave;
            }
            set
            {
                SetProperty(ref _canSave, value);
            }

        }

        private bool CanCloseExecute()
        {
            return CanClose;
        }

        private void CloseExecute()
        {
            _model.CloseApplication();
        }

        public bool CanClose
        {
            get
            {
                var canClose = _canClose;
                return canClose;
            }
            set =>SetProperty(ref _canClose , value);
        }

        #region CanCreateNew

        public bool CanCreateNew
        {
            get { return _canCreateNew; }
            set { SetProperty(ref _canCreateNew, value); }
        }

        private void CreateNewExecute()
        {
          var tmpFileName=_model.CreateDocument();

        }

        private bool CanCreateNewExecute()
        {
            return CanCreateNew;
        }
#endregion



    }
}