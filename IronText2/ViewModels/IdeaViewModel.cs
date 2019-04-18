using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace IronText2.ViewModels
{
    public class IdeaViewModel:BindableBase
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
