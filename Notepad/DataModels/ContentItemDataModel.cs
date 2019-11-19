using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.DataModels
{
    public class ContentItemDataModel
    {
        public string Color { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        string[] colors = { "#FE9899", "#FFE2C5", "#41CDCC" };

        public ContentItemDataModel()
        {
            Color = colors[new Random().Next(colors.Length)];
            Title = "NoneNoneNoneNoneNoneNoneNoneNoneNone";
            Description = "NoneNoneNoneNoneNone\nNoneNoneNoneNoneNonevNone\nNoneNoneNoneNoneNoneNone";
        }
    }
}
