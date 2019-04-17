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
                TextChanged(value);
                SetProperty(ref _text, value);
            }
        }

        private void TextChanged(string value)
        {
            if (string.IsNullOrEmpty(value)|| value.Length==0)
            {
                IsEmpty = true;
                _eventAggregator.GetEvent<TextEmptyEvent>().Publish();
            }
            else
            {
                if (IsEmpty)
                {
                    IsEmpty = false;
                    _eventAggregator.GetEvent<TextPopulatedEvent>().Publish();
                }
            }
        }

     }
}