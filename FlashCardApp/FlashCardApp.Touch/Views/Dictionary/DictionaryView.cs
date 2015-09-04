
using System;
using CoreGraphics;
using System.Windows;
using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.ViewModels.Dictionary;
using ObjCRuntime;
using FlashCardApp.Core.Entities;
using MonoTouch;
using FlashCardApp.Core.ViewModels;

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

				var selectedItem = (WithCommand<SearchResult>)source.SelectedItem;
				selectedItem.Command.Execute(null);
			} ;



			set.Bind(SearchTypeSegmentedControl).To(ViewModel=>ViewModel.SearchInputType).Mode(Cirrious.MvvmCross.Binding.MvxBindingMode.TwoWay);

			set.Apply ();

			SearchTypeSegmentedControl.SelectedSegment = 1;

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

