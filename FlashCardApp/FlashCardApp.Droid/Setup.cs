using System;
using System.IO;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core;
using FlashCardApp.Core.DAL;

namespace FlashCardApp.Droid
{
    public class Setup : MvxAndroidSetup
    {
        const string dbname = "Dictionary.sqlite";
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
            try
            {
              


                string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                // Console.WriteLine("Data path:" + Database.DatabaseFilePath);
                string dbFile = Path.Combine(docFolder, dbname); // FILE NAME TO USE WHEN COPIED
                if (!File.Exists(dbFile))
                {
                    Stream s = applicationContext.Assets.Open("Dictionary.sqlite");
                    //var s = Resources.OpenRawResource(Resource.Raw.Dictionary);  // DATA FILE RESOURCE ID
                    var writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write);
                    ReadWriteStream(s, writeStream);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            Mvx.RegisterSingleton<ISQLiteConnection>(new DroidSqliteConnection());
            base.InitializeLastChance();
        }

        private void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            var buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}