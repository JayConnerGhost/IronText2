using System;
using System.CodeDom;
using System.Configuration;
using System.Windows;
using IronText2.Events;
using IronText2.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace IronText2.ViewModels
{
    public class MenuViewModel : WorkspaceViewModel
    {
        private readonly MenuModel _model;
        private readonly IEventAggregator _eventAggregator;

        //Fix needed here once the turn off and on checking of dependancy understood 
        private bool _canCreateNew=true;
        private bool _canClose=true;
        private bool _canSave=true;
        private bool _isTextSelected=true;
        private bool _isClipboardPopulated=true;
        private bool _isTextPopulated=true;
        private bool _canOpen;


        public DelegateCommand FileNewCommand { get; private set; }
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand FileSaveCommand { get; private set; }
        public DelegateCommand FileSaveAsCommand { get; private set; }
      
        public DelegateCommand EditCopyCommand { get; private set; }
        public DelegateCommand EditCutCommand { get; private set; }
        public DelegateCommand EditPasteCommand { get; private set; }
        public DelegateCommand EditSelectAllCommand { get; private set; }
        public DelegateCommand FileOpenCommand { get; private set; }

        public MenuViewModel(MenuModel model, IEventAggregator eventAggregator)
        {
            _model = model;
            _eventAggregator = eventAggregator;
            FileNewCommand =
                new DelegateCommand(CreateNewExecute, CanCreateNewExecute).ObservesProperty(() => CanCreateNew);
            CloseCommand = new DelegateCommand(CloseExecute, CanCloseExecute).ObservesProperty(() => CanClose);
            FileSaveCommand = new DelegateCommand(SaveExecute, CanSaveExecute).ObservesProperty(() => CanSave);
            FileSaveAsCommand = new DelegateCommand(SaveAsExecute, CanSaveAsExecute).ObservesProperty(() => CanSave);
            FileOpenCommand = new DelegateCommand(OpenFileExecute, CanOpenFileExecute).ObservesProperty(() => CanOpen);


            EditCopyCommand =new DelegateCommand(EditCopyExecute, CanEditCopyExecute).ObservesProperty(() => IsTextSelected);
            EditCutCommand =new DelegateCommand(EditCutExecute, CanEditCutExecute).ObservesProperty(() => IsTextSelected);
            EditPasteCommand = new DelegateCommand(EditPasteExecute, CanEditPasteExecute).ObservesProperty(() => IsClipboardPopulated);
            EditSelectAllCommand = new DelegateCommand(EditSelectAllTextExecute, CanEditSelectAllTextExecute).ObservesProperty(() => IsTextPopulated);
          
        }

        private bool CanOpenFileExecute()
        {
            return true;
        }

        private void OpenFileExecute()
        {
           _eventAggregator.GetEvent<FileOpenEvent>().Publish();
        }

        public bool CanOpen
        {
            get
            {
                bool canOpen = _canOpen;
                return canOpen;
            }
            set
            {
                SetProperty(ref _canOpen, value);

            }
        }


        private bool CanSaveAsExecute()
        {
            return _canSave;
        }

        private bool CanEditSelectAllTextExecute()
        {
            return IsTextPopulated;
        }

        private void EditSelectAllTextExecute()
        {
            _eventAggregator.GetEvent<SelectAllTextEvent>().Publish(true);
        }

        public bool IsTextPopulated
        {
            get
            {
                bool isTextPopulated = _isTextPopulated;
                //TODO code in here to work out if text is empty
                return isTextPopulated;
            }
            set
            {
                SetProperty(ref _isTextSelected, value);

            }
        }

        private bool CanEditPasteExecute()
        {
            return true;
        }

        private void EditPasteExecute()
        {
            _eventAggregator.GetEvent<PasteTextEvent>().Publish();
        }

        public bool IsClipboardPopulated
        {
            get
            {
                //TODO: code in here to find out if clipboard has contents 

                bool isClipboardPopulated = true;
                return isClipboardPopulated;
            }
            set
            {
                SetProperty(ref _isClipboardPopulated,value);

            }
        }

      
        private bool CanEditCutExecute()
        {
            return true;
        }

        private void EditCutExecute()
        {
            _eventAggregator.GetEvent<CutTextEvent>().Publish();
        }

        private bool CanEditCopyExecute()
        {
            return true;
        }

        private void EditCopyExecute()
        {
            _eventAggregator.GetEvent<CopyTextEvent>().Publish();
        }

        private void SaveAsExecute()
        {
            _eventAggregator.GetEvent<FileSaveAsEvent>().Publish();
        }

        private bool CanSaveExecute()
        {
            return _canSave;
        }

        private void SaveExecute()
        {
            _eventAggregator.GetEvent<FileSaveEvent>().Publish();
        
        }

        public bool IsTextSelected
        {
            get
            {
                var isTextSelected = _isTextSelected;
                return isTextSelected;
            }
            set
            {
                SetProperty(ref _isTextSelected , value);

            }
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
          

        }

        private bool CanCreateNewExecute()
        {
            return CanCreateNew;
        }
#endregion



    }
}