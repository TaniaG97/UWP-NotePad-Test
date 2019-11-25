using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.DataModels
{
    public class AttachedFileModel
    {
        public int Id { get; set; }
        public string AttachedFileName { get; set; }

        public int ItemId { get; set; }
        public ContentItemDataModel Item { get; set; }

        public AttachedFileModel()
        {
            AttachedFileName = string.Empty;
        }
    }
}
