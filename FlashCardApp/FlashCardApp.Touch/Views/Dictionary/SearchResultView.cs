
using System;
using CoreGraphics;

using Foundation;
using UIKit;
using ObjCRuntime;
using Cirrious.MvvmCross.Binding.Touch.Views;
using FlashCardApp.Core.ViewModels.Dictionary;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Touch
{
	public partial class SearchResultView : MvxViewController
	{

		public SearchResultViewModel ViewModel {
			get {
				return (SearchResultViewModel)base.ViewModel;
			}
			set {
				base.ViewModel = value;
			}
		}

		public SearchResultView () : base ("SearchResultView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// ios7 layout
			if (RespondsToSelector (new Selector ("edgesForExtendedLayout"))) {
				EdgesForExtendedLayout = UIRectEdge.None;
			}




			var source = new MvxSimpleTableViewSource(FlashCardSetTableView, FlashCardSetTableViewCell.Key, FlashCardSetTableViewCell.Key);
			FlashCardSetTableView.Source = source;

			var set = this.CreateBindingSet<SearchResultView, SearchResultViewModel> ();
			set.Bind (SimplifiedLabel).To (ViewModel => ViewModel.TheSearchResult.Simplified);
			set.Bind (TraditionalLabel).To (ViewModel => ViewModel.TheSearchResult.Traditional);
			set.Bind (PinyinLabel).To (ViewModel => ViewModel.TheSearchResult.AccentedPinyin).TwoWay();
			set.Bind (DefinitionLabel).To (ViewModel => ViewModel.TheSearchResult.DefintionsString);

			set.Bind (source).To (ViewModel => ViewModel.FlashCardSets);



			set.Bind (AddToSetButton).To ("AddCardToSetCommand");


			set.Bind (source).To (v => v.FlashCardSets);

			source.SelectedItemChanged += (object sender, EventArgs e) => {

				var selectedItem = (FlashCardSet)source.SelectedItem;
				ViewModel.SelectedFlashCardSet = selectedItem;
			};

			set.Bind (source).For ("SelectedItemChanged").To ("ShowDetailCommand");

			set.Apply ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

