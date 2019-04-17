using Prism.Mvvm;

namespace IronText2.Models
{
    public class TextContentModel:BindableBase
    {
        public string FileName { get; set; }
        public string Text { get; set; }
    }
}