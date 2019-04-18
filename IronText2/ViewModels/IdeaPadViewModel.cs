using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronText2.Extensions;
using IronText2.Models;

namespace IronText2.ViewModels
{
    public class IdeaPadViewModel:WorkspaceViewModel
    {
        private readonly IdeasModel _model;
      


        public IdeaPadViewModel(IdeasModel model)
        {
            _model = model;
        }

        //call model for data bindable property for collection in here 
        public ObservableCollection<IdeaViewModel> Ideas
        {
            get { return _model.ideas.ConvertToIdeaViewModelCollection(); }
            set
            {
                //this code may not work as expected be ready to change it 
                var models = value.ConvertToIdeaModelCollection();
                _model.ideas = models;
            }
        }


    }
}
