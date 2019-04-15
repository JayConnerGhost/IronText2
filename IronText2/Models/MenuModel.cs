using System;
using Prism.Mvvm;

namespace IronText2.Models
{
    public class MenuModel:BindableBase
    {
        public void CloseApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void Save(string fileName, string text)
        {
            throw new System.NotImplementedException();
        }

        public string CreateDocument()
        {
            throw new NotImplementedException();
        }
    }
}