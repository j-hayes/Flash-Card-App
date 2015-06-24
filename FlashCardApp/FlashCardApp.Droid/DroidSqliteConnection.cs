using System;
using System.IO;
using FlashCardApp.Core.DAL;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace FlashCardApp.Droid
{
    public class DroidSqliteConnection : ISQLiteConnection
    {
        const string dbname = "Dictionary.sqlite";
        public SQLiteConnection connection
        {
            get
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    dbname);
                var platform = new SQLitePlatformAndroid();
                return new SQLiteConnection(platform, dbPath);
            }
        }
    }
}