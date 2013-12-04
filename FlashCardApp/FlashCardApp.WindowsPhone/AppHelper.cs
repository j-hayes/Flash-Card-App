using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FlashCardApp.WindowsPhone
{
    internal static class AppHelper
    {
        public static StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
        public static StorageFolder localFolder = ApplicationData.Current.LocalFolder;

        public static async Task<bool> ExistsInStorageFolder(this StorageFolder folder, string fileName)
        {
            try
            {
                await folder.GetFileAsync(fileName);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
    }
}
