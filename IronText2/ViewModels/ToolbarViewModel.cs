using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace IronText2.ViewModels
{
    public class ToolbarViewModel : BindableBase
    {
        private string _testText = "this is the tool bar";
        public string TestText
        {
            get { return _testText; }
            set { SetProperty(ref _testText, value); }
        }

    }

}
