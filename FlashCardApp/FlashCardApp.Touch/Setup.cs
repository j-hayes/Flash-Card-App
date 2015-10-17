using Cirrious.CrossCore;
using UIKit;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross;
using FlashCardApp.Core.DAL;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.Touch.Platform;

namespace FlashCardApp.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		protected override void InitializeLastChance()
		{
			Mvx.RegisterSingleton<ISQLiteConnection>(new TouchSqliteConnection());
			base.InitializeLastChance();
		}
	}
}