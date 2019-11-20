using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.DataModels
{
    public class CategoryDataModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public ObservableCollection<ContentItemDataModel> ContentItems { get; set; }

        public override string ToString()
        {
            return Title;
        }

        public CategoryDataModel()
        {
            string[] colors = { "#FE9899", "#FFE2C5", "#41CDCC" };
            Color = colors[new Random().Next(colors.Length)];
            Title = "Title";
            ContentItems = new ObservableCollection<ContentItemDataModel>();
        }

    }
}
