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
	[Register ("FlashCardDetailsView")]
	partial class FlashCardDetailsView
	{
		[Outlet]
		UIKit.UITextView DefinitionTextView { get; set; }

		[Outlet]
		UIKit.UISwitch EditModeSwitch { get; set; }

		[Outlet]
		UIKit.UIScrollView InputScrollView { get; set; }

		[Outlet]
		UIKit.UITextField PinyinTextField { get; set; }

		[Outlet]
		UIKit.UIButton SaveCardButton { get; set; }

		[Outlet]
		UIKit.UITextField SimplifiedTextField { get; set; }

		[Outlet]
		UIKit.UITextField TraditionalTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (InputScrollView != null) {
				InputScrollView.Dispose ();
				InputScrollView = null;
			}

			if (DefinitionTextView != null) {
				DefinitionTextView.Dispose ();
				DefinitionTextView = null;
			}

			if (EditModeSwitch != null) {
				EditModeSwitch.Dispose ();
				EditModeSwitch = null;
			}

			if (PinyinTextField != null) {
				PinyinTextField.Dispose ();
				PinyinTextField = null;
			}

			if (SaveCardButton != null) {
				SaveCardButton.Dispose ();
				SaveCardButton = null;
			}

			if (SimplifiedTextField != null) {
				SimplifiedTextField.Dispose ();
				SimplifiedTextField = null;
			}

			if (TraditionalTextField != null) {
				TraditionalTextField.Dispose ();
				TraditionalTextField = null;
			}
		}
	}
}
