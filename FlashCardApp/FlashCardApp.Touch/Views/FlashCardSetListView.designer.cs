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
	[Register ("FlashCardSetListView")]
	partial class FlashCardSetListView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton AddNewSetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView FlashCardSetsTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField NewSetNameTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FlashCardSetsTableView != null) {
				FlashCardSetsTableView.Dispose ();
				FlashCardSetsTableView = null;
			}

			if (NewSetNameTextField != null) {
				NewSetNameTextField.Dispose ();
				NewSetNameTextField = null;
			}

			if (AddNewSetButton != null) {
				AddNewSetButton.Dispose ();
				AddNewSetButton = null;
			}
		}
	}
}