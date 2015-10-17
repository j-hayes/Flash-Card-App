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
	[Register ("HomePageView")]
	partial class HomePageView
	{
		[Outlet]
		UIKit.UIButton DictionaryButton { get; set; }

		[Outlet]
		UIKit.UIButton FlashcardButton { get; set; }

		[Outlet]
		UIKit.UIButton SaveCardsButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DictionaryButton != null) {
				DictionaryButton.Dispose ();
				DictionaryButton = null;
			}

			if (FlashcardButton != null) {
				FlashcardButton.Dispose ();
				FlashcardButton = null;
			}

			if (SaveCardsButton != null) {
				SaveCardsButton.Dispose ();
				SaveCardsButton = null;
			}
		}
	}
}
