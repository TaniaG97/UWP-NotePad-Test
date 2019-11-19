using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.DataModels
{
    public class CategorieDataModel
    {
        public string Color { get; set; }
        public string Title { get; set; }
        public ObservableCollection<ContentItemDataModel> ContentItems { get; set; }

        string[] colors = { "#FE9899", "#FFE2C5", "#41CDCC" };

        public CategorieDataModel()
        {
            Color = colors[new Random().Next(colors.Length)];
            Title = "None";
            ContentItems = new ObservableCollection<ContentItemDataModel>();
        }
    }
}
