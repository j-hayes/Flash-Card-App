
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.ViewModels.Dictionary;

namespace FlashCardApp.Touch
{
	public partial class DictionaryResultCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("DictionaryResultCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("DictionaryResultCell");

		public DictionaryResultCell (IntPtr handle) : base (handle)
		{
			this.DelayBind (() => {
				var set = this.CreateBindingSet<DictionaryResultCell, DictionarySearchResult> ();

				set.Bind (SimplifiedLabel).To (x => x.Simplified);
				set.Bind (TraditionalLabel).To (x => x.Traditional);	
				set.Bind (PinyinLabel).To (x => x.Pinyin);
				set.Bind (DefinitionLabel).To (x => x.Definition);
				set.Apply();
			});
		}

		public static DictionaryResultCell Create ()
		{
			return (DictionaryResultCell)Nib.Instantiate (null, null) [0];
		}
	}
}

