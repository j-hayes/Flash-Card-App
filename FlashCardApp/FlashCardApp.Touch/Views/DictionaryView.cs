using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using FlashCardApp.Core.ViewModels.Dictionary;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;


using MonoTouch.CoreFoundation;

namespace FlashCardApp.Touch.Views
{
    public partial class DictionaryView : MvxViewController
    {
        public DictionaryView()
            : base("DictionaryView", null)
        {

        }

     
        public override void ViewDidLoad()
        {
			base.ViewDidLoad();

			// ios7 layout
			if (RespondsToSelector (new Selector ("edgesForExtendedLayout"))) {
				EdgesForExtendedLayout = UIRectEdge.None;
			}
            


			ResultsTableView.ScrollEnabled = true;




			var source = new MvxSimpleTableViewSource(ResultsTableView, DictionaryResultCell.Key, DictionaryResultCell.Key);

			ResultsTableView.Source = source;

			var set = this.CreateBindingSet<DictionaryView, DictionaryViewModel> ();

			set.Bind(SearchInputTypeChooser).To(ViewModel=>ViewModel.SearchInputType).Mode(Cirrious.MvvmCross.Binding.MvxBindingMode.OneWayToSource);

			set.Bind (FilterTextField).To (vm => vm.Filter);//.Mode (Cirrious.MvvmCross.Binding.MvxBindingMode.TwoWay);
			set.Bind (source).To (vm => vm.SearchResults);

			source.SelectedItemChanged += (object sender, EventArgs e) => {

				var selectedItem = (SearchResult)source.SelectedItem;
				((DictionaryViewModel)ViewModel).SelectedSearchResult = selectedItem;
			};


				set.Apply ();

			SearchInputTypeChooser.SelectedSegment = 0;

			SearchInputTypeChooser.ValueChanged += (object sender, EventArgs e) => {
				if (SearchInputTypeChooser.SelectedSegment == 0) {
					((DictionaryViewModel)ViewModel).SearchInputType = DictionarySearchInputType.Chinese;
				} else if (SearchInputTypeChooser.SelectedSegment == 1) {
					((DictionaryViewModel)ViewModel).SearchInputType = DictionarySearchInputType.English;
				} else if (SearchInputTypeChooser.SelectedSegment == 2) {
					((DictionaryViewModel)ViewModel).SearchInputType = DictionarySearchInputType.Pinyin;
				}
			};

			ResultsTableView.ReloadData();
			var gesture = new UITapGestureRecognizer(() =>
				{
					FilterTextField.ResignFirstResponder();

				});
			gesture.CancelsTouchesInView = false;

			View.AddGestureRecognizer(gesture);

            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}