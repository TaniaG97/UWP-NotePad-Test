using Notepad.DataModels;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Notepad.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GridViewFrame : Page
    {
        public MainViewModel ViewModel => App.ViewModel;
        public GridViewFrame()
        {
            ViewModel.IsGridView = true;
            this.InitializeComponent();
        }

        private void ListViewButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListViewFrame));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ContentItemDataModel item = (ContentItemDataModel)((Button)sender).DataContext;
            ViewModel.DeleteItemFromCategory(item);
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ChoosedCategory.ContentItems.Add(new ContentItemDataModel());
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridViewItem = MyGridView.ContainerFromItem(e.ClickedItem) as GridViewItem;
            ContentItemDataModel item = (ContentItemDataModel)gridViewItem.Content;
            ViewModel.EditingItem = item;
            Frame.Navigate(typeof(EditItemFrame));
        }
    }
}
