
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;



namespace FlashCardApp.Touch
{
	public partial class DictionaryView : MvxViewController
	{
		[
		public DictionaryView () : base ("DictionaryView", null)
		{
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
				var source = new MvxStandardTableViewSource(TableView, "TitleText")
					// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

