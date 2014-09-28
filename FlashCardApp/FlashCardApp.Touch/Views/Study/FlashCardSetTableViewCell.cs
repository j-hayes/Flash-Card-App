using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.ViewModels.Dictionary;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Touch
{
	public partial class FlashCardSetTableViewCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("FlashCardSetTableViewCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("FlashCardSetTableViewCell");

		public FlashCardSetTableViewCell (IntPtr handle) : base (handle)
		{
			this.DelayBind (() => {

				SetNameLabel.AdjustsFontSizeToFitWidth = true; 
			

				var set = this.CreateBindingSet<FlashCardSetTableViewCell, FlashCardSet> ();

				set.Bind (SetNameLabel).To (x => x.SetName); // eventaully make this both characters and traditional in Search Result VM
				set.Bind (NumberOfCardsLabel).To(x=>x.FlashCards.Count);
				//set.Bind (EnglishLabel).To (x => x.DefintionsString);
				set.Apply();
		});
		}

		public static FlashCardSetTableViewCell Create ()
		{
			return (FlashCardSetTableViewCell)Nib.Instantiate (null, null) [0];
		}
	}
}

