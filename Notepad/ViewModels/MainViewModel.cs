using Notepad.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ObservableCollection<CategorieDataModel> Categories { get; set; }
            = new ObservableCollection<CategorieDataModel>();

        public CategorieDataModel ChoosedCategory { get; set; }
        public ContentItemDataModel EditingItem { get; set; }

        bool isGridView;
        bool isListView;
        public bool IsGridView
        {
            get { return isGridView; }
            set
            {
                isGridView = value;
                isListView = !isGridView;
            }
        }
        public bool IsListView
        {
            get { return isListView; }
            set
            {
                isListView = value;
                isGridView = !isListView;
            }
        }

        public MainViewModel()
        {
            for (int i=0; i<3;i++)
            {
                CategorieDataModel category = new CategorieDataModel();
                category.ContentItems.Add(new ContentItemDataModel());
                category.ContentItems.Add(new ContentItemDataModel());
                category.ContentItems.Add(new ContentItemDataModel());
                Categories.Add(category);
            }

            ChoosedCategory = Categories[0];           
        }

        public void DeleteItemFromCategory(ContentItemDataModel _item)
        {
            ChoosedCategory.ContentItems.Remove(_item);
        }

        public void DeleteCategory(CategorieDataModel _category)
        {
            if(_category== ChoosedCategory)
            {
                Categories.Remove(_category);
                ChoosedCategory = Categories[0];
            }
            else
            {
                Categories.Remove(_category);
            }
            
        }

    }
}
