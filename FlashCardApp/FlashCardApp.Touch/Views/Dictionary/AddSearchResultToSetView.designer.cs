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
	[Register ("AddSearchResultToSetView")]
	partial class AddSearchResultToSetView
	{
		[Outlet]
		UIKit.UIScrollView ContentView { get; set; }

		[Outlet]
		UIKit.UIView controlsView { get; set; }

		[Outlet]
		UIKit.UIButton CreateCustomCardButton { get; set; }

		[Outlet]
		UIKit.UILabel DefinitionLabel { get; set; }

		[Outlet]
		UIKit.UILabel PinyinLabel { get; set; }

		[Outlet]
		UIKit.UIScrollView ScrollView { get; set; }

		[Outlet]
		UIKit.UITableView SetsTableView { get; set; }

		[Outlet]
		UIKit.UILabel SimplifiedLabel { get; set; }

		[Outlet]
		UIKit.UILabel TraditionalLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (controlsView != null) {
				controlsView.Dispose ();
				controlsView = null;
			}

			if (ContentView != null) {
				ContentView.Dispose ();
				ContentView = null;
			}

			if (CreateCustomCardButton != null) {
				CreateCustomCardButton.Dispose ();
				CreateCustomCardButton = null;
			}

			if (DefinitionLabel != null) {
				DefinitionLabel.Dispose ();
				DefinitionLabel = null;
			}

			if (PinyinLabel != null) {
				PinyinLabel.Dispose ();
				PinyinLabel = null;
			}

			if (ScrollView != null) {
				ScrollView.Dispose ();
				ScrollView = null;
			}

			if (SetsTableView != null) {
				SetsTableView.Dispose ();
				SetsTableView = null;
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
