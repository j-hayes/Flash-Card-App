// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace FlashCardApp.Touch.Views
{
	[Register ("DictionaryView")]
	partial class DictionaryView
	{
		[Outlet]
		MonoTouch.UIKit.UILabel filterLabel_delete { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField FilterTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView ResultsTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FilterTextField != null) {
				FilterTextField.Dispose ();
				FilterTextField = null;
			}

			if (filterLabel_delete != null) {
				filterLabel_delete.Dispose ();
				filterLabel_delete = null;
			}

			if (ResultsTableView != null) {
				ResultsTableView.Dispose ();
				ResultsTableView = null;
			}
		}
	}
}
