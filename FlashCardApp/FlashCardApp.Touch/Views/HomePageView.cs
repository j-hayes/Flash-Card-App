
using System;
using CoreGraphics;

using System.IO;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.ViewModels;
using Cirrious.MvvmCross.ViewModels;



namespace FlashCardApp.Touch
{

	public sealed partial class HomePageView : MvxTabBarViewController
	{

		private int _createdSoFarCount;
		public HomePageViewModel viewModel { get 
			{ return (HomePageViewModel)ViewModel; }
			set{ ViewModel = value;}
		}
			
		public HomePageView ()
		{
			_createdSoFarCount = 0;
			ViewDidLoad ();//need this additional call because UIKit creates the view before the C# heirarchy is constructed 

		}

		public override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();
			if (ViewModel == null) {
				return;
			}
			var viewControllers = new UIViewController[]
			{
					CreateTabFor("Dictionary", "dictionary", viewModel.DictionaryViewModel),
					CreateTabFor("Settings", "gear", viewModel.StudyFlashCardSetSettingsViewModel),
					CreateTabFor("Flash Cards", "pencil", viewModel.FlashCardListViewModel),
			};
				ViewControllers = viewControllers;
				CustomizableViewControllers = new UIViewController[] { };
				SelectedViewController = ViewControllers[0];	

		

			// Perform any additional setup after loading the view, typically from a nib.
		}
	
		private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
		{
			var controller = new UINavigationController();
			var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
			SetTitleAndTabBarItem(screen, title, imageName);
			controller.PushViewController(screen, false);
			return controller;
		}

		private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
		{
			screen.Title = title;
			screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle("Images/Tabs/" + imageName + ".png"),
				_createdSoFarCount);
			_createdSoFarCount++;
		}
	}
}