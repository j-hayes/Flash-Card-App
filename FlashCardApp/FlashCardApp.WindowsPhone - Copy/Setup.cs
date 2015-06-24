using System;
using System.IO;
using Windows.Storage;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using FlashCardApp.Core.DAL;
using Microsoft.Phone.Controls;
using SQLite.Net;
using SQLite.Net.Platform.WindowsPhone8;

namespace FlashCardApp.WindowsPhone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            Mvx.RegisterSingleton<ISQLiteConnection>(new WindowsPhoneSqliteConnection());
            base.InitializeLastChance();
        }
    }

    public class WindowsPhoneSqliteConnection : ISQLiteConnection
    {
        public SQLiteConnection connection
        {
            get
            {
                string path = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "Dictionary.sqlite"));//DataBase Name 
                SQLitePlatformWP8 platform = new SQLitePlatformWP8();
                return new SQLiteConnection(platform, path);
            }
        }
    }
}