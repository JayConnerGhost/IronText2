using System.Collections.Generic;
using System.Collections.ObjectModel;
using IronText2.Models;
using IronText2.ViewModels;
using System.Linq;
namespace IronText2.Extensions
{
    public static class IdeasExtensions
    {

        public static ObservableCollection<IdeaViewModel> ConvertToIdeaViewModelCollection(this IList<IdeaModel> source)
        {
            var target=new ObservableCollection<IdeaViewModel>();
            foreach (var model in source)
            {
                target.Add(new IdeaViewModel(){Id=model.Id,Text = model.Text});
            }
          
            return target;
        }

        public static IList<IdeaModel> ConvertToIdeaModelCollection(this ObservableCollection<IdeaViewModel> source)
        {
            return new List<IdeaModel>();
        }
    }
}