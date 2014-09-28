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
	[Register ("SearchResultView")]
	partial class SearchResultView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton AddToSetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel DefinitionLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView FlashCardSetTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel PinyinLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SimplifiedLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TraditionalLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddToSetButton != null) {
				AddToSetButton.Dispose ();
				AddToSetButton = null;
			}

			if (DefinitionLabel != null) {
				DefinitionLabel.Dispose ();
				DefinitionLabel = null;
			}

			if (FlashCardSetTableView != null) {
				FlashCardSetTableView.Dispose ();
				FlashCardSetTableView = null;
			}

			if (PinyinLabel != null) {
				PinyinLabel.Dispose ();
				PinyinLabel = null;
			}

			if (SimplifiedLabel != null) {
				SimplifiedLabel.Dispose ();
				SimplifiedLabel = null;
			}

			if (TraditionalLabel != null) {
				TraditionalLabel.Dispose ();
				TraditionalLabel = null;
			}
		}
	}
}
