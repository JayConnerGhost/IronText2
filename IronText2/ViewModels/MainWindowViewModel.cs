using Prism.Mvvm;

namespace IronText2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "IronText2";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
