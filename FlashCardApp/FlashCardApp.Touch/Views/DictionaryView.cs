using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using FlashCardApp.Core.ViewModels.Dictionary;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FlashCardApp.Touch.Views
{
    public partial class DictionaryView : MvxViewController
    {
        public DictionaryView()
            : base("DictionaryView", null)
        {

         


        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
           

            View = new UIView() { BackgroundColor = UIColor.Blue };
            base.ViewDidLoad();

            var searchField = new UITextField(new RectangleF(10, 10, 300, 40));
            Add(searchField);

            var tableView = new UITableView(new RectangleF(0, 50, 320, 500), UITableViewStyle.Plain);
            var source = new MvxStandardTableViewSource(tableView, "TitleText");
            tableView.Source = source;
            Add(tableView);

            
            var set = this.CreateBindingSet<DictionaryView, DictionaryViewModel>();
            set.Bind(searchField).To(vm => vm.SearchTerm);
            set.Bind(source).To(vm => vm.SearchResults);



            tableView.ReloadData();



            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}