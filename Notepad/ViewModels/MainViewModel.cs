using Microsoft.EntityFrameworkCore;
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
        public ObservableCollection<CategoryDataModel> Categories { get; set; }
            = new ObservableCollection<CategoryDataModel>();

        public ObservableCollection<ContentItemDataModel> Items { get; set; }
            = new ObservableCollection<ContentItemDataModel>();
        public ObservableCollection<AttachedFileModel> AttachedFiles { get; set; }
            = new ObservableCollection<AttachedFileModel>();

        public CategoryDataModel ChoosedCategory { get; set; }
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

        public void Initialise()
        {
            using (DataContext db = new DataContext())
            {
                Items = new ObservableCollection<ContentItemDataModel>(db.Items.Include(x => x.Category).ToList());
                Categories = new ObservableCollection<CategoryDataModel>(db.Categories.ToList());
                AttachedFiles = new ObservableCollection<AttachedFileModel>(db.AttachedFiles.Include(x => x.Item).ToList());
            }
            if (Categories.Count == 0)
            {
                AddCategory(new CategoryDataModel());
            }
            ChoosedCategory = Categories[0];
        }

        public void AddItem(ContentItemDataModel _item)
        {
            using (DataContext db = new DataContext())
            {
                db.Categories.Attach(ChoosedCategory);
                db.Items.Add(_item);
                db.SaveChanges();
            }
            //ChoosedCategory.ContentItems.Add(_item);
        }

        public void AddCategory(CategoryDataModel _category)
        {
            using (DataContext db = new DataContext())
            {
                db.Categories.Add(_category);
                db.SaveChanges();
            }
            Categories.Add(_category);
        }

        public void EditeItem()
        {
            using (DataContext db = new DataContext())
            {
                db.Items.Update(EditingItem);
                db.SaveChanges();
            }
        }

        public void EditeCategory(CategoryDataModel _category)
        {

        }

        public void DeleteItem(ContentItemDataModel _item)
        {
            using (DataContext db = new DataContext())
            {
                db.Items.Remove(_item);
                db.SaveChanges();
            }
            ChoosedCategory.ContentItems.Remove(_item);
        }

        public void DeleteCategory(CategoryDataModel _category)
        {
            using (DataContext db = new DataContext())
            {
                db.Categories.Remove(_category);
                db.SaveChanges();
            }
            if (_category== ChoosedCategory)
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
