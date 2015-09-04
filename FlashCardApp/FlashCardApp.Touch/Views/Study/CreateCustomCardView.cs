
using System;
using CoreGraphics;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using FlashCardApp.Core.ViewModels.Study;
using ObjCRuntime;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace FlashCardApp.Touch
{
	public partial class CreateCustomCardView : MvxViewController
	{
		public CreateCustomCardView () : base ("CreateCustomCardView", null)
		{
		}

		private FlashCardApp.Core.ViewModels.Study.CreateCustomCardViewModel  ViewModel {
			get {
				return (FlashCardApp.Core.ViewModels.Study.CreateCustomCardViewModel)base.ViewModel;
			}
			set {
				base.ViewModel = value;
			}
		}


		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			// ios7 layout
			if (RespondsToSelector (new Selector ("edgesForExtendedLayout"))) {
				EdgesForExtendedLayout = UIRectEdge.None;
			}






			var set = this.CreateBindingSet<CreateCustomCardView, FlashCardApp.Core.ViewModels.Study.CreateCustomCardViewModel> ();

			// todo add fields and wire them to viewmodel. push up the changes in this repo
			//rebuild project on PC: update nugets in core, add reference to sqlite for runtime
			//then you should be good to go again.

			//set.Bind (SubmitButton).To ("SubmitSettingsCommand");


			set.Apply ();

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

