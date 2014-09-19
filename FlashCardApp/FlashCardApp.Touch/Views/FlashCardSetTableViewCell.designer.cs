// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace FlashCardApp.Touch
{
	[Register ("FlashCardSetTableViewCell")]
	partial class FlashCardSetTableViewCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel NumberOfCardsLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SetNameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NumberOfCardsLabel != null) {
				NumberOfCardsLabel.Dispose ();
				NumberOfCardsLabel = null;
			}

			if (SetNameLabel != null) {
				SetNameLabel.Dispose ();
				SetNameLabel = null;
			}
		}
	}
}
