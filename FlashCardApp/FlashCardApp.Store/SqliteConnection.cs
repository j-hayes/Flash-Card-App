using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using FlashCardApp.Core.DAL;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace FlashCardApp.Store
{
    public class WindowsSqliteConnection : ISQLiteConnection
    {
        public SQLiteConnection connection
        {
            get
            {
                string path = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "Dictionary.sqlite"));//DataBase Name 
                SQLitePlatformWinRT platform = new SQLitePlatformWinRT();
                return new SQLiteConnection(platform, path);
            }
        }
    }
}
