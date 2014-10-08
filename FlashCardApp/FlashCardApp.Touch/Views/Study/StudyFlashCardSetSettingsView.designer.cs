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
	[Register ("StudyFlashCardSetSettingsView")]
	partial class StudyFlashCardSetSettingsView
	{
		[Outlet]
		MonoTouch.UIKit.UISlider MaxNumberOfCardsScroller { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField MaxNumberOfCardsText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView PageScrollView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ShowCharactersFirstSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ShowDefinitionFirstSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ShowDefinitionSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ShowPinyinFirstSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ShowPinyinSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ShowSimplifiedSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ShowTraditionalSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SubmitButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PageScrollView != null) {
				PageScrollView.Dispose ();
				PageScrollView = null;
			}

			if (ShowSimplifiedSwitch != null) {
				ShowSimplifiedSwitch.Dispose ();
				ShowSimplifiedSwitch = null;
			}

			if (ShowTraditionalSwitch != null) {
				ShowTraditionalSwitch.Dispose ();
				ShowTraditionalSwitch = null;
			}

			if (ShowPinyinSwitch != null) {
				ShowPinyinSwitch.Dispose ();
				ShowPinyinSwitch = null;
			}

			if (ShowDefinitionSwitch != null) {
				ShowDefinitionSwitch.Dispose ();
				ShowDefinitionSwitch = null;
			}

			if (MaxNumberOfCardsScroller != null) {
				MaxNumberOfCardsScroller.Dispose ();
				MaxNumberOfCardsScroller = null;
			}

			if (MaxNumberOfCardsText != null) {
				MaxNumberOfCardsText.Dispose ();
				MaxNumberOfCardsText = null;
			}

			if (ShowCharactersFirstSwitch != null) {
				ShowCharactersFirstSwitch.Dispose ();
				ShowCharactersFirstSwitch = null;
			}

			if (ShowDefinitionFirstSwitch != null) {
				ShowDefinitionFirstSwitch.Dispose ();
				ShowDefinitionFirstSwitch = null;
			}

			if (ShowPinyinFirstSwitch != null) {
				ShowPinyinFirstSwitch.Dispose ();
				ShowPinyinFirstSwitch = null;
			}

			if (SubmitButton != null) {
				SubmitButton.Dispose ();
				SubmitButton = null;
			}
		}
	}
}
