using System.Windows;
using IronText2.Events;
using Prism.Events;
using Prism.Mvvm;

namespace IronText2.ViewModels
{
    public class TextContentViewModel: WorkspaceViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private string _text;
        private string _selectedText;

        public TextContentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
          
        }

        public string TextContent
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }


        public string CurrentSelectedText
        {
            get { return _selectedText;}
            set { SetProperty(ref _selectedText, value); }
        }
     }
}