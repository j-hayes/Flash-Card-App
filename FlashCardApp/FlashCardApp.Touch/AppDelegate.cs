using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.ViewModels;
using System.Threading;
using System.IO;
using System;
using FlashCardApp.Core.ViewModels;

namespace FlashCardApp.Touch
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		UIWindow _window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			string dbname = "Dictionary.sqlite";
			string pathToDeployed = Path.Combine( Environment.GetFolderPath (Environment.SpecialFolder.Personal), dbname);
			string assetDatabasePath = Path.Combine (NSBundle.MainBundle.BundlePath, dbname);


			Console.WriteLine ("In App Delegate");

			if (File.Exists(assetDatabasePath)) {
				Console.WriteLine ("Asset Database Content Does exist at path");
			}



			if (!File.Exists (pathToDeployed)) {
				Console.WriteLine ("DB file Didn't Exist on app");
				File.Copy (assetDatabasePath, pathToDeployed);

			} else {
				Console.WriteLine ("DB file Did Exist");
			}

			_window = new UIWindow (UIScreen.MainScreen.Bounds);

			var setup = new Setup(this, _window);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			 
			startup.Start();

			_window.MakeKeyAndVisible ();


			return true;
		}
	}
}