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
	[Register ("StudyFlashCardSetSettingsView")]
	partial class StudyFlashCardSetSettingsView
	{
		[Outlet]
		UIKit.UIView contentView { get; set; }

		[Outlet]
		UIKit.UISlider MaxCardsSlider { get; set; }

		[Outlet]
		UIKit.UISlider MaxNumberOfCardsScroller { get; set; }

		[Outlet]
		UIKit.UITextField MaxNumberOfCardsText { get; set; }

		[Outlet]
		UIKit.UIScrollView PageScrollView { get; set; }

		[Outlet]
		UIKit.UITableView SetsTableView { get; set; }

		[Outlet]
		UIKit.UISwitch ShowCharactersFirstSwitch { get; set; }

		[Outlet]
		UIKit.UISwitch ShowDefinitionFirstSwitch { get; set; }

		[Outlet]
		UIKit.UISwitch ShowDefinitionSwitch { get; set; }

		[Outlet]
		UIKit.UISwitch ShowPinyinFirstSwitch { get; set; }

		[Outlet]
		UIKit.UISwitch ShowPinyinSwitch { get; set; }

		[Outlet]
		UIKit.UISwitch ShowSimplifiedSwitch { get; set; }

		[Outlet]
		UIKit.UISwitch ShowTraditionalSwitch { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MaxCardsSlider != null) {
				MaxCardsSlider.Dispose ();
				MaxCardsSlider = null;
			}

			if (contentView != null) {
				contentView.Dispose ();
				contentView = null;
			}

			if (MaxNumberOfCardsScroller != null) {
				MaxNumberOfCardsScroller.Dispose ();
				MaxNumberOfCardsScroller = null;
			}

			if (MaxNumberOfCardsText != null) {
				MaxNumberOfCardsText.Dispose ();
				MaxNumberOfCardsText = null;
			}

			if (PageScrollView != null) {
				PageScrollView.Dispose ();
				PageScrollView = null;
			}

			if (SetsTableView != null) {
				SetsTableView.Dispose ();
				SetsTableView = null;
			}

			if (ShowCharactersFirstSwitch != null) {
				ShowCharactersFirstSwitch.Dispose ();
				ShowCharactersFirstSwitch = null;
			}

			if (ShowDefinitionFirstSwitch != null) {
				ShowDefinitionFirstSwitch.Dispose ();
				ShowDefinitionFirstSwitch = null;
			}

			if (ShowDefinitionSwitch != null) {
				ShowDefinitionSwitch.Dispose ();
				ShowDefinitionSwitch = null;
			}

			if (ShowPinyinFirstSwitch != null) {
				ShowPinyinFirstSwitch.Dispose ();
				ShowPinyinFirstSwitch = null;
			}

			if (ShowPinyinSwitch != null) {
				ShowPinyinSwitch.Dispose ();
				ShowPinyinSwitch = null;
			}

			if (ShowSimplifiedSwitch != null) {
				ShowSimplifiedSwitch.Dispose ();
				ShowSimplifiedSwitch = null;
			}

			if (ShowTraditionalSwitch != null) {
				ShowTraditionalSwitch.Dispose ();
				ShowTraditionalSwitch = null;
			}
		}
	}
}
