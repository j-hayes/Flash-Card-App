
using System;
using System.Drawing;
using System.Windows;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.ViewModels.Dictionary;
using MonoTouch.ObjCRuntime;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Touch
{
	public partial class DictionaryView : MvxViewController
	{
		public DictionaryViewModel viewModel { 
			get {
				return (DictionaryViewModel)base.ViewModel; 
			}
			set {
				base.ViewModel = value;
			}
		}
		public DictionaryView () : base ("DictionaryView", null)
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

			if (RespondsToSelector (new Selector ("edgesForExtendedLayout"))) {
				EdgesForExtendedLayout = UIRectEdge.None;
			}


			var source = new MvxSimpleTableViewSource(SearchResultsTableView, DictionaryResultCell.Key, DictionaryResultCell.Key);

			SearchResultsTableView.Source = source;

			var set = this.CreateBindingSet<DictionaryView, DictionaryViewModel> ();

			set.Bind (FilterTextField).To (v => v.Filter).TwoWay();
			set.Bind (source).To (v => v.SearchResults).TwoWay();



			source.SelectedItemChanged += (object sender, EventArgs e) => {

				var selectedItem = (SearchResult)source.SelectedItem;
				viewModel.SelectedSearchResult = selectedItem;
				viewModel.ShowSearchResultViewModel();
			} ;

			set.Bind(source).For ("SelectedItemChanged").To ("SelectedSearchResultChangedCommand");

			set.Bind(SearchTypeSegmentedControl).To(ViewModel=>ViewModel.SearchInputType).Mode(Cirrious.MvvmCross.Binding.MvxBindingMode.OneWayToSource);

			set.Apply ();

			SearchTypeSegmentedControl.SelectedSegment = 0;

			SearchTypeSegmentedControl.ValueChanged += (object sender, EventArgs e) => {
				if (SearchTypeSegmentedControl.SelectedSegment == 0) {
					((DictionaryViewModel)viewModel).SearchInputType = DictionarySearchInputType.Chinese;
				}  else if (SearchTypeSegmentedControl.SelectedSegment == 1) {
					((DictionaryViewModel)viewModel).SearchInputType = DictionarySearchInputType.English;
				}  else if (SearchTypeSegmentedControl.SelectedSegment == 2) {
					((DictionaryViewModel)viewModel).SearchInputType = DictionarySearchInputType.Pinyin;
				}
			} ;

			SearchResultsTableView.ReloadData();
			var gesture = new UITapGestureRecognizer(() =>
				{
					FilterTextField.ResignFirstResponder();

				} );
			gesture.CancelsTouchesInView = false;

			View.AddGestureRecognizer(gesture);

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

