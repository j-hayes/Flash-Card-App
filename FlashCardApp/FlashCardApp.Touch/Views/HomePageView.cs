
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace FlashCardApp.Touch
{

	public partial class HomePageView : MvxViewController
	{

		public HomePageView () : base ("HomePageView", null)
		{
		}

		public override void ViewDidLoad ()
		{




			base.ViewDidLoad ();


			var set = this.CreateBindingSet<HomePageView, Core.ViewModels.HomePageViewModel>();

			set.Bind(DictionaryButton).To("DictionaryCommand");
			set.Bind(FlashcardButton).To("FlashCardCommand");
			set.Bind(SaveCardsButton).To("SaveCardCloudCommand");



			set.Apply ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

