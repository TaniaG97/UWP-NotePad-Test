using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.DataModels
{
    public class ContentItemDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public List<AttachedFileModel> AttachedFiles { get; set; }
        
        public int CategoryId { get; set; }
        public CategoryDataModel Category { get; set; }

        public ContentItemDataModel()
        {
            string[] colors = { "#FE9899", "#FFE2C5", "#41CDCC" };
            Color = colors[new Random().Next(colors.Length)];
            Title = "Title";
            Description = "Description";
            AttachedFiles = new List<AttachedFileModel>();
        }
    }
}
