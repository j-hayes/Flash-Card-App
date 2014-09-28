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
	[Register ("FlashCardSetDetailsView")]
	partial class FlashCardSetDetailsView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton CardDetailsButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton DeleteCardButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton DeleteSetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView FlashCardTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SetNameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SetNameLabel != null) {
				SetNameLabel.Dispose ();
				SetNameLabel = null;
			}

			if (FlashCardTableView != null) {
				FlashCardTableView.Dispose ();
				FlashCardTableView = null;
			}

			if (DeleteCardButton != null) {
				DeleteCardButton.Dispose ();
				DeleteCardButton = null;
			}

			if (CardDetailsButton != null) {
				CardDetailsButton.Dispose ();
				CardDetailsButton = null;
			}

			if (DeleteSetButton != null) {
				DeleteSetButton.Dispose ();
				DeleteSetButton = null;
			}
		}
	}
}
