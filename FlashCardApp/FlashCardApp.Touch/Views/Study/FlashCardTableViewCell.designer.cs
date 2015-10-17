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
	[Register ("FlashCardTableViewCell")]
	partial class FlashCardTableViewCell
	{
		[Outlet]
		UIKit.UILabel EnglishLabel { get; set; }

		[Outlet]
		UIKit.UILabel PinyinLabel { get; set; }

		[Outlet]
		UIKit.UILabel SimplifiedLabel { get; set; }

		[Outlet]
		UIKit.UILabel TraditionalLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SimplifiedLabel != null) {
				SimplifiedLabel.Dispose ();
				SimplifiedLabel = null;
			}

			if (TraditionalLabel != null) {
				TraditionalLabel.Dispose ();
				TraditionalLabel = null;
			}

			if (PinyinLabel != null) {
				PinyinLabel.Dispose ();
				PinyinLabel = null;
			}

			if (EnglishLabel != null) {
				EnglishLabel.Dispose ();
				EnglishLabel = null;
			}
		}
	}
}
