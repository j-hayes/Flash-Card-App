// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FlashCardApp.Touch
{
	[Register ("FlashCardSetDetailsView")]
	partial class FlashCardSetDetailsView
	{
		[Outlet]
		UIKit.UIButton AddCustomCardButton { get; set; }

		[Outlet]
		UIKit.UIButton CardDetailsButton { get; set; }

		[Outlet]
		UIKit.UIButton DeleteCardButton { get; set; }

		[Outlet]
		UIKit.UIButton DeleteSetButton { get; set; }

		[Outlet]
		UIKit.UITableView FlashCardTableView { get; set; }

		[Outlet]
		UIKit.UILabel SetNameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CardDetailsButton != null) {
				CardDetailsButton.Dispose ();
				CardDetailsButton = null;
			}

			if (DeleteCardButton != null) {
				DeleteCardButton.Dispose ();
				DeleteCardButton = null;
			}

			if (DeleteSetButton != null) {
				DeleteSetButton.Dispose ();
				DeleteSetButton = null;
			}

			if (FlashCardTableView != null) {
				FlashCardTableView.Dispose ();
				FlashCardTableView = null;
			}

			if (SetNameLabel != null) {
				SetNameLabel.Dispose ();
				SetNameLabel = null;
			}

			if (AddCustomCardButton != null) {
				AddCustomCardButton.Dispose ();
				AddCustomCardButton = null;
			}
		}
	}
}
