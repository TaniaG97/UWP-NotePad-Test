using Notepad.DataModels;
using Notepad.Pages;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Notepad
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel => App.ViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            FrameContent.Navigate(typeof(GridViewFrame));
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SpliteViewMenu.IsPaneOpen = !SpliteViewMenu.IsPaneOpen;
        }

        private void AddCategorieButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Categories.Add(new CategorieDataModel());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CategorieDataModel item = (CategorieDataModel)((Button)sender).DataContext;
            ViewModel.DeleteCategory(item);
            UpdateFrame();
        }

        private void CategoriesList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var listViewItem = CategoriesList.ContainerFromItem(e.ClickedItem) as ListViewItem;
            CategorieDataModel item = (CategorieDataModel)listViewItem.Content;
            ViewModel.ChoosedCategory = item;
            UpdateFrame();
        }

        private void UpdateFrame()
        {
            if (ViewModel.IsGridView)
            {
                FrameContent.Navigate(typeof(GridViewFrame));
            }
            else if(ViewModel.IsListView)
            {
                FrameContent.Navigate(typeof(ListViewFrame));
            }
        }
    }
}
