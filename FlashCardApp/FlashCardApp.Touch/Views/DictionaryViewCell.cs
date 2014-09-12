﻿
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FlashCardApp.Touch
{
	public class DictionaryViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("DictionaryViewCell");

		public DictionaryViewCell () : base (UITableViewCellStyle.Value1, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = "TextLabel";
		}
	}
}

