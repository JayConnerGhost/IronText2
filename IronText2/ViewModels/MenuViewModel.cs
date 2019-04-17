using IronText2.Events;
using IronText2.Models;
using Prism.Commands;
using Prism.Events;

namespace IronText2.ViewModels
{
    public class MenuViewModel : WorkspaceViewModel
    {
        private readonly MenuModel _model;
        private readonly IEventAggregator _eventAggregator;

        //Fix needed here once the turn off and on checking of dependancy understood 
        private bool _canCreateNew=true;
        private bool _canClose=true;
        private bool _isClipboardPopulated=true;
        private bool _isTextPopulated=false;
        private bool _canOpen=true;


        public DelegateCommand FileNewCommand { get;  set; }
        public DelegateCommand CloseCommand { get;  set; }
        public DelegateCommand FileSaveCommand { get;  set; }
        public DelegateCommand FileSaveAsCommand { get;  set; }
      
        public DelegateCommand EditCopyCommand { get;  set; }
        public DelegateCommand EditCutCommand { get;  set; }
        public DelegateCommand EditPasteCommand { get;  set; }
        public DelegateCommand EditSelectAllCommand { get;  set; }
        public DelegateCommand FileOpenCommand { get;  set; }

        public MenuViewModel(MenuModel model, IEventAggregator eventAggregator)
        {
            _model = model;
            _eventAggregator = eventAggregator;
            FileNewCommand =
                new DelegateCommand(CreateNewExecute, CanCreateNewExecute).ObservesProperty(() => CanCreateNew);
            CloseCommand = new DelegateCommand(CloseExecute, CanCloseExecute).ObservesProperty(() => CanClose);
            FileSaveCommand = new DelegateCommand(SaveExecute, CanSaveExecute).ObservesProperty(() => IsTextPopulated);
            FileSaveAsCommand = new DelegateCommand(SaveAsExecute, CanSaveAsExecute).ObservesProperty(() => IsTextPopulated);
            FileOpenCommand = new DelegateCommand(OpenFileExecute, CanOpenFileExecute).ObservesProperty(() => CanOpen);


            EditCopyCommand =new DelegateCommand(EditCopyExecute, CanEditCopyExecute).ObservesProperty(() => IsTextPopulated);
            EditCutCommand =new DelegateCommand(EditCutExecute, CanEditCutExecute).ObservesProperty(() => IsTextPopulated);
            EditPasteCommand = new DelegateCommand(EditPasteExecute, CanEditPasteExecute).ObservesProperty(() => IsClipboardPopulated);
            EditSelectAllCommand = new DelegateCommand(EditSelectAllTextExecute, CanEditSelectAllTextExecute).ObservesProperty(() => IsTextPopulated);

            _eventAggregator.GetEvent<TextEmptyEvent>().Subscribe(TextEmpty);
            _eventAggregator.GetEvent<TextPopulatedEvent>().Subscribe(TextNowPopulated);

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
                SetProperty(ref _isTextPopulated, value);

            }
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

        public bool CanClose
        {
            get
            {
                var canClose = _canClose;
                return canClose;
            }
            set =>SetProperty(ref _canClose , value);
        }

        public bool CanCreateNew
        {
            get { return _canCreateNew; }
            set { SetProperty(ref _canCreateNew, value); }
        }

        private void TextEmpty()
        {
            IsTextPopulated = false;
       
        }

        private void TextNowPopulated()
        {
            IsTextPopulated = true;
        }

        private bool CanOpenFileExecute()
        {
            return _canOpen;
        }

        private void OpenFileExecute()
        {
           _eventAggregator.GetEvent<FileOpenEvent>().Publish();
        }


        private bool CanSaveAsExecute()
        {
            return IsTextPopulated;
        }

        private bool CanEditSelectAllTextExecute()
        {
            return IsTextPopulated;
        }

        private void EditSelectAllTextExecute()
        {
            _eventAggregator.GetEvent<SelectAllTextEvent>().Publish(true);
        }

        private bool CanEditPasteExecute()
        {
            return IsClipboardPopulated;
        }

        private void EditPasteExecute()
        {
            _eventAggregator.GetEvent<PasteTextEvent>().Publish();
        }


        private bool CanEditCutExecute()
        {
            return IsTextPopulated;
        }

        private void EditCutExecute()
        {
            _eventAggregator.GetEvent<CutTextEvent>().Publish();
        }

        private bool CanEditCopyExecute()
        {
            return IsTextPopulated;
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
            return IsTextPopulated;
        }

        private void SaveExecute()
        {
            _eventAggregator.GetEvent<FileSaveEvent>().Publish();
        
        }


        private bool CanCloseExecute()
        {
            return CanClose;
        }

        private void CloseExecute()
        {
            _model.CloseApplication();
        }


        private void CreateNewExecute()
        {
            _eventAggregator.GetEvent<CreateNewEvent>().Publish();
        }

        private bool CanCreateNewExecute()
        {
            return CanCreateNew;
        }

    }
}