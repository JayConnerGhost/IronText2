using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace IronText2.Models
{
    public class IdeasModel:BindableBase
    {
        public IList<IdeaModel> ideas { get; set; }

        public IdeasModel()
        {
            ideas=new List<IdeaModel>();

            //dev data
            ideas.Add(new IdeaModel(){Id=1, Text="test text for item 1"});
            ideas.Add(new IdeaModel(){Id=3, Text="test text for item 2"});
            ideas.Add(new IdeaModel(){Id=4, Text="test text for item 3"});
            ideas.Add(new IdeaModel(){Id=5, Text="test text for item 4"});
            ideas.Add(new IdeaModel(){Id=6, Text="test text for item 5"});
            ideas.Add(new IdeaModel(){Id=7, Text="test text for item 6"});
            ideas.Add(new IdeaModel(){Id=8, Text="test text for item 7"});
            ideas.Add(new IdeaModel(){Id=9, Text="test text for item 8"});
            ideas.Add(new IdeaModel(){Id=10, Text="test text for item 9"});
            ideas.Add(new IdeaModel(){Id=11, Text="test text for item 10"});
            ideas.Add(new IdeaModel(){Id=12, Text="test text for item 11"});
            ideas.Add(new IdeaModel(){Id=13, Text="test text for item 12"});
            ideas.Add(new IdeaModel(){Id=14, Text="test text for item 13"});
            ideas.Add(new IdeaModel(){Id=15, Text="test text for item 14"});
            ideas.Add(new IdeaModel(){Id=16, Text="test text for item 15"});
            ideas.Add(new IdeaModel(){Id=17, Text="test text for item 16"});
        }
    }
}
