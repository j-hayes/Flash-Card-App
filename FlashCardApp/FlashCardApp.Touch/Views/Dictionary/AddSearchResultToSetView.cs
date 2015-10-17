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
	public partial class AddSearchResultToSetView : MvxViewController
	{
		public AddSearchResultToSetView () : base ("AddSearchResultToSetView", null)
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

			ScrollView.ContentSize = controlsView.Bounds.Size;


			var source = new MvxSimpleTableViewSource (SetsTableView, SetNameWithCommandTableViewCell.Key, SetNameWithCommandTableViewCell.Key);

			SetsTableView.Source = source;

			var set = this.CreateBindingSet<AddSearchResultToSetView, AddSearchResultToSetViewModel>();

			set.Bind (source).To (ViewModel => ViewModel.SetList);

			SetsTableView.AllowsMultipleSelection = false;

			source.SelectedItemChanged += (object sender, EventArgs e) => {
				var selectedSet = (WithCommand<FlashCardSet>)source.SelectedItem;
				selectedSet.Command.Execute(null);
				// todo: display added message
			};

			set.Bind (SimplifiedLabel).To (ViewModel => ViewModel.Card.Simplified);
			set.Bind (TraditionalLabel).To (ViewModel => ViewModel.Card.Traditional);
			set.Bind (PinyinLabel).To (ViewModel => ViewModel.Card.Pinyin);
			set.Bind (DefinitionLabel).To (ViewModel => ViewModel.Card.Definition);

			set.Bind (CreateCustomCardButton).To (ViewModel => ViewModel.CreateCustomCardCommand);

			set.Apply ();
		}


	}
}

