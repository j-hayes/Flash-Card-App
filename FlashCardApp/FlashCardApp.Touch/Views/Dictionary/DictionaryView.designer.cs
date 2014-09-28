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
	[Register ("DictionaryView")]
	partial class DictionaryView
	{
		[Outlet]
		MonoTouch.UIKit.UITextField FilterTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView SearchResultsTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl SearchTypeSegmentedControl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SearchTypeSegmentedControl != null) {
				SearchTypeSegmentedControl.Dispose ();
				SearchTypeSegmentedControl = null;
			}

			if (FilterTextField != null) {
				FilterTextField.Dispose ();
				FilterTextField = null;
			}

			if (SearchResultsTableView != null) {
				SearchResultsTableView.Dispose ();
				SearchResultsTableView = null;
			}
		}
	}
}
