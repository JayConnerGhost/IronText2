using System.Windows;
using IronText2.Events;
using Prism.Events;
using Prism.Mvvm;

namespace IronText2.ViewModels
{
    public class TextContentViewModel: WorkspaceViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public TextContentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SelectAllTextEvent>().Subscribe(SelectAllText);
        }

        private void SelectAllText(bool selectAll)
        {
            if (selectAll)
            {
                //Q. how to select all text
                MessageBox.Show("Recived");
            }
        }
    }
}