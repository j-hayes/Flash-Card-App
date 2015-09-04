
using System;
using CoreGraphics;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using FlashCardApp.Core.ViewModels.Study;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Touch
{
	public partial class FlashCardSetDetailsView : MvxViewController
	{
		public FlashCardSetDetailsView () : base ("FlashCardSetDetailsView", null)
		{
		}

		public FlashCardSetDetailsViewModel ViewModel { 
			get {
				return (FlashCardSetDetailsViewModel)base.ViewModel;
			}
			set {
				base.ViewModel = value; 
			}

		}



	

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var source = new MvxSimpleTableViewSource(FlashCardTableView, FlashCardTableViewCell.Key, FlashCardTableViewCell.Key);

			FlashCardTableView.Source = source;


			var set = this.CreateBindingSet<FlashCardSetDetailsView, FlashCardSetDetailsViewModel> ();
			set.Bind (SetNameLabel).To (ViewModel => ViewModel.Set.SetName);
			set.Bind (source).To (ViewModel => ViewModel.SetCards);

			source.SelectedItemChanged += (object sender, EventArgs e) => 
			{
				ViewModel.SelectedCard = (FlashCard)source.SelectedItem;
			};

			set.Bind (DeleteCardButton).To ("DeleteCardCommand");
			set.Bind (DeleteSetButton).To ("DeleteSetCommand");
			set.Bind (CardDetailsButton).To ("ShowCardDetailCommand");

			set.Apply ();

	}
}
}
