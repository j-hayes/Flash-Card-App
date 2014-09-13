using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using FlashCardApp.Core.ViewModels.Dictionary;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.CoreFoundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

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
           
			// ios7 layout
			if (RespondsToSelector (new Selector ("edgesForExtendedLayout"))) {
				EdgesForExtendedLayout = UIRectEdge.None;
			}
             base.ViewDidLoad();

//            var searchField = new UITextField(new RectangleF(10, 10, 300, 40));
//            Add(searchField);
//
//            var tableView = new UITableView(new RectangleF(0, 50, 320, 500), UITableViewStyle.Plain);
//			tableView.RowHeight = 180;

			var source = new MvxSimpleTableViewSource(ResultsTableView, DictionaryResultCell.Key, DictionaryResultCell.Key);
			ResultsTableView.Source = source;


			var subTotalTextField = new UITextField(new RectangleF(10, 40, 300, 40));

            
            var set = this.CreateBindingSet<DictionaryView, DictionaryViewModel>();
			set.Bind(FilterTextField).To(vm => vm.Filter).Mode(Cirrious.MvvmCross.Binding.MvxBindingMode.TwoWay);
            set.Bind(source).To(vm => vm.SearchResults);
			set.Bind (filterLabel_delete).To (ViewModel => ViewModel.Filter).Mode(Cirrious.MvvmCross.Binding.MvxBindingMode.TwoWay);

			set.Apply ();

			ResultsTableView.ReloadData();
			var gesture = new UITapGestureRecognizer(() =>
				{
					FilterTextField.ResignFirstResponder();
				});
			View.AddGestureRecognizer(gesture);

            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}