
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using FlashCardApp.Core.Entities;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace FlashCardApp.Touch
{
	public partial class FlashCardTableViewCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("FlashCardTableViewCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("FlashCardTableViewCell");

		public FlashCardTableViewCell (IntPtr handle) : base (handle)
		{
			this.DelayBind (() => {

				var set = this.CreateBindingSet<FlashCardTableViewCell, FlashCard> ();

				set.Bind (SimplifiedLabel).To (x => x.Simplified); // eventaully make this both characters and traditional in Search Result VM
				set.Bind (TraditionalLabel).To(x=>x.Traditional);
				set.Bind (PinyinLabel).To(x=>x.AccentedPinyin);
				set.Bind (EnglishLabel).To (x => x.Definition);
				set.Apply();
			});

		}

		public static FlashCardTableViewCell Create ()
		{
			return (FlashCardTableViewCell)Nib.Instantiate (null, null) [0];
		}
	}
}

