
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
	public partial class DictionaryResultCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("DictionaryResultCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("DictionaryResultCell");


		public DictionaryResultCell (IntPtr handle) : base (handle)
		{

		

			this.DelayBind (() => {
				CharactersLabel.AdjustsFontSizeToFitWidth = true; 
				PinyinLabel.AdjustsFontSizeToFitWidth = true; 
				DefinitionLabel.AdjustsFontSizeToFitWidth = true; 

				var set = this.CreateBindingSet<DictionaryResultCell, SearchResult> ();

				set.Bind (CharactersLabel).To (x => x.Simplified); // eventaully make this both characters and traditional in Search Result VM
				set.Bind (PinyinLabel).To (x => x.AccentedPinyin);	
				set.Bind (DefinitionLabel).To (x => x.DefintionsString);

				set.Apply();
			});
		}

		public static DictionaryResultCell Create ()
		{
			return (DictionaryResultCell)Nib.Instantiate (null, null) [0];
		}
	}
}

