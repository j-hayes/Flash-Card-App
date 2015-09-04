using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FlashCardApp.Core.DAL;
using AVFoundation;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

namespace FlashCardApp.Touch
{
    public class TouchSqliteConnection : ISQLiteConnection
    {
        public SQLiteConnection connection
        {
            get
            {
				string pathToDeployed = Path.Combine( Environment.GetFolderPath (Environment.SpecialFolder.Personal), "Dictionary.sqlite");
			    SQLitePlatformIOS platform = new SQLitePlatformIOS();
				return new SQLiteConnection(platform, pathToDeployed);
            }
        }
    }
}
