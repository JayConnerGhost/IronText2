using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IronText2.Events;
using IronText2.Models;
using Microsoft.Win32;
using Prism.Events;

namespace IronText2.Views
{
    /// <summary>
    /// Interaction logic for TextContentView.xaml
    /// </summary>
    public partial class TextContentView : UserControl
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly TextContentModel _model;


        public TextContentView(IEventAggregator eventAggregator, TextContentModel model)
        {
            _eventAggregator = eventAggregator;
            _model = model;

            InitializeComponent();
            _eventAggregator.GetEvent<SelectAllTextEvent>().Subscribe(SelectAllText);
            _eventAggregator.GetEvent<CutTextEvent>().Subscribe(CutText);
            _eventAggregator.GetEvent<CopyTextEvent>().Subscribe(CopyText);
            _eventAggregator.GetEvent<PasteTextEvent>().Subscribe(PasteText);
            _eventAggregator.GetEvent<FileSaveEvent>().Subscribe(SaveText);
            _eventAggregator.GetEvent<FileSaveAsEvent>().Subscribe(SaveTextAs);
            _eventAggregator.GetEvent<FileOpenEvent>().Subscribe(FileOpen);
            
        }

        private void FileOpen()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (openFileDialog.ShowDialog() == true)
            {
                Text.Text = File.ReadAllText(openFileDialog.FileName);
                _model.FileName = openFileDialog.FileName;
            }
        }


        private void SaveText()
        {
            if (!string.IsNullOrEmpty(_model.FileName))
            {
                File.WriteAllText(_model.FileName, Text.Text);
            }
            else
            {
                SaveTextAs();
            }

           
        }


        private void SaveTextAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs|all Files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, Text.Text);
            _model.FileName = saveFileDialog.FileName;
        }

    private void PasteText()
        {
           Text.Paste();
        }

        private void CopyText()
        {
            if (Text.SelectedText.Length > 0)
            {
                Text.Copy();
            }
        }

        private void CutText()
        {
            if (Text.SelectedText.Length > 0)
            {
                Text.Cut();
            }
        }

        private void SelectAllText(bool captureSelection)
        {
            if (captureSelection)
            {
                Text.SelectionStart = 0;
                Text.SelectionLength = Text.Text.Length;
            }
       
        }
    }
}
