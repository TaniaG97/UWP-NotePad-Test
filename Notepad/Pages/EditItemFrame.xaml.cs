using Notepad.DataModels;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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

            List<AttachedFileModel> attachedFile = ViewModel.EditingItem.AttachedFiles;
            attachedFile.ForEach(file =>
            {
                AttachFile(file.AttachedFileName);
            });
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
            //Hider.Background = radioButton.Background;
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
            Bindings.Update();
        }

        private async void AddFileButton_Click(object sender, RoutedEventArgs e)
        {          
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".txt");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            StorageFolder localFolder = await Package.Current.InstalledLocation.GetFolderAsync("Assets");

            if (file != null)
            {                
                await file.CopyAsync(localFolder, file.Name, NameCollisionOption.ReplaceExisting);
                ViewModel.EditingItem.AttachedFiles.Add(new AttachedFileModel() {AttachedFileName = file.Name });
                AttachFile(file.Name);
            }           
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.EditeItem();
        }

        private async void AttachFile(string fileName)
        {

            StorageFile file = await Package.Current.InstalledLocation.GetFileAsync(@"Assets\" + fileName);

            if (file != null)
            {
                ThumbnailMode thumbnailMode = ThumbnailMode.PicturesView;

                StorageItemThumbnail thumb = await file.GetScaledImageAsThumbnailAsync(thumbnailMode);
                if (thumb != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(thumb);

                    Image image = new Image();
                    image.Width = 300;
                    image.Height = 300;
                    image.Stretch = Stretch.Uniform;
                    image.Source = bitmapImage;
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    AttachedFilesPanel.Children.Add(image);

                    TextBlock txtBox = new TextBlock();
                    txtBox.Text = fileName;                    
                    AttachedFilesPanel.Children.Add(txtBox);
                }
            }
        }

        
    }
}
