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
	[Register ("DictionaryResultCell")]
	partial class DictionaryResultCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel CharactersLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel DefinitionLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel PinyinLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CharactersLabel != null) {
				CharactersLabel.Dispose ();
				CharactersLabel = null;
			}

			if (DefinitionLabel != null) {
				DefinitionLabel.Dispose ();
				DefinitionLabel = null;
			}

			if (PinyinLabel != null) {
				PinyinLabel.Dispose ();
				PinyinLabel = null;
			}
		}
	}
}