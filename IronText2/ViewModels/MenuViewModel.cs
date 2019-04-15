using System.CodeDom;
using System.Configuration;
using Prism.Commands;
using Prism.Mvvm;

namespace IronText2.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private bool _canCreateNew=true;
        private bool _canClose=true;

        public DelegateCommand FileNewCommand { get; private set; }
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand FileSaveCommand { get; private set; }
        public DelegateCommand FileSaveAsCommand { get; private set; }
        public DelegateCommand FileSaveAllCommand { get; private set; }

        public DelegateCommand EditCopyCommand { get; private set; }
        public DelegateCommand EditCutCommand { get; private set; }
        public DelegateCommand EditFilePasteCommand { get; private set; }
        public DelegateCommand EditFileSelectAllCommand { get; private set; }


        public MenuViewModel()
        {
            FileNewCommand=new DelegateCommand(CreateNewExecute,CanCreateNewExecute).ObservesProperty(()=>CanCreateNew);
            CloseCommand=new DelegateCommand(CloseExecute,CanCloseExecute).ObservesProperty(()=>CanClose);
        }

        private bool CanCloseExecute()
        {
            return CanClose;
        }

        private void CloseExecute()
        {
            System.Windows.Application.Current.Shutdown();
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
            //TODO: implement file save logic 
        
        }

        private bool CanCreateNewExecute()
        {
            return CanCreateNew;
        }
#endregion



    }
}