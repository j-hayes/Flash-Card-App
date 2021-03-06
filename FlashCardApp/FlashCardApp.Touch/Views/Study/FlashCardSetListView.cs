
using System;
using CoreGraphics;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using ObjCRuntime;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.ViewModels.Study;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.ViewModels;

namespace FlashCardApp.Touch
{
	public partial class FlashCardSetListView : MvxViewController
	{

		private FlashCardSetListViewModel ViewModel {
			get {
				return (FlashCardSetListViewModel)base.ViewModel;
			}
			set {
				base.ViewModel = value;
			}
		}

		public FlashCardSetListView () : base ("FlashCardSetListView", null)
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




			var source = new MvxSimpleTableViewSource(FlashCardSetsTableView, FlashCardSetTableViewCell.Key, FlashCardSetTableViewCell.Key);
			FlashCardSetsTableView.Source = source;

			var set = this.CreateBindingSet<FlashCardSetListView, FlashCardSetListViewModel> ();
			set.Bind (NewSetNameTextField).To (ViewModel => ViewModel.NewSetName).TwoWay();
			set.Bind (AddNewSetButton).To ("AddSetCommand");
			

			set.Bind (source).To (v => v.FlashCardSets);

			source.SelectedItemChanged += (object sender, EventArgs e) => {

				var selectedItem = (WithCommand<FlashCardSet>)source.SelectedItem;
				ViewModel.SelectedSet = selectedItem.Item;
				selectedItem.Command.Execute(null);

			};
		
	

			set.Apply ();

			var gesture = new UITapGestureRecognizer(() =>
				{
					NewSetNameTextField.ResignFirstResponder();

				});
			gesture.CancelsTouchesInView = false;

			View.AddGestureRecognizer(gesture);
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

