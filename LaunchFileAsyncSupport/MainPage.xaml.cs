using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LaunchFileAsyncSupport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Path to the file in the app package to launch
            //string imageFile = @"Assets\pic.png";
            //var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);


        //    var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync
        //(Windows.Storage.KnownLibraryId.Pictures);
        //    Windows.Storage.StorageFolder savePicturesFolder = myPictures.SaveFolder;
        //    var file = await savePicturesFolder.GetFileAsync("pictures.png");

            //get file from sd card
            StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;

            // Get the first child folder, which represents the SD card.
            StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();
            string imageFile = @"Assets\pic.png";
            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

            var file1 = file.CopyAsync(sdCard, "test.png");

            var file2 = await sdCard.GetFileAsync("test.png");

            if (file2 != null)
            {
                // Launch the retrieved file
                var success = await Windows.System.Launcher.LaunchFileAsync(file);
                if (file != null)
            {
                // Launch the retrieved file
                var success2 = await Windows.System.Launcher.LaunchFileAsync(file);
                if (success)
                {
                    // File launched
                }
                else
                {
                    // File launch failed
                }
            }
            else
            {
                // Could not find file
            }
        }
    }
}
