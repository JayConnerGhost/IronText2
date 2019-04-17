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
        private bool IsEmpty = true;


        public TextContentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
          
        }

        public string TextContent
        {
            get { return _text; }
            set
            {
                SetProperty(ref _text, value);
                TextChanged(value);
            }
        }

        private void TextChanged(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                IsEmpty = true;
                _eventAggregator.GetEvent<TextEmptyEvent>().Publish();
            }

            if (IsEmpty)
            {
                IsEmpty = false;
                _eventAggregator.GetEvent<TextPopulatedEvent>().Publish();
            }
        }


        public string CurrentSelectedText
        {
            get { return _selectedText;}
            set { SetProperty(ref _selectedText, value); }
        }
     }
}