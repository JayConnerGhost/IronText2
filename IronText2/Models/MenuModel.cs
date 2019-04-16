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

       
    }
}