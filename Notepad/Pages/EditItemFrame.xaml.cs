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
    public sealed partial class EditItemFrame : Page
    {
        public MainViewModel ViewModel => App.ViewModel;
        public EditItemFrame()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.EditingItem.Title = ((TextBox)sender).Text;
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.EditingItem.Description = ((TextBox)sender).Text;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            Hider.Background = radioButton.Background;
            string color=null;
            switch (radioButton.Name)
            {
                case "Red":
                    color = "#FE9899";
                    break;
                case "Yellow":
                    color = "#FFE2C5";
                    break;
                case "Blue":
                    color = "#41CDCC";
                    break;
            }
            ViewModel.EditingItem.Color = color;
        }

        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
