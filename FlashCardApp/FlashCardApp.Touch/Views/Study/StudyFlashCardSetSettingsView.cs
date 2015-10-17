using System.Windows.Input;
using System;
using CoreGraphics;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using ObjCRuntime;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.ViewModels.Study;
using Cirrious.MvvmCross.Binding.Touch.Views;
using FlashCardApp.Core.ViewModels;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Touch
{
	public partial class StudyFlashCardSetSettingsView : MvxViewController
	{
		public StudyFlashCardSetSettingsView () : base ("StudyFlashCardSetSettingsView", null)
		{
		}

		private StudyFlashCardSetSettingsViewModel  ViewModel {
			get {
				return (StudyFlashCardSetSettingsViewModel)base.ViewModel;
			}
			set {
				base.ViewModel = value;
			}
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

			PageScrollView.ContentSize = contentView.Bounds.Size;


			var source = new MvxSimpleTableViewSource (SetsTableView, SetNameWithCommandTableViewCell.Key, SetNameWithCommandTableViewCell.Key);

			SetsTableView.Source = source;

			var set = this.CreateBindingSet<StudyFlashCardSetSettingsView, StudyFlashCardSetSettingsViewModel> ();


			set.Bind (source).To (ViewModel => ViewModel.SetList);

			SetsTableView.AllowsMultipleSelection = false;

			source.SelectedItemChanged += (object sender, EventArgs e) => {
				var selectedSet = (WithCommand<FlashCardSet>)source.SelectedItem;
				selectedSet.Command.Execute(null);
				// todo: display added message
			};




			set.Bind (MaxNumberOfCardsScroller).To (ViewModel => ViewModel.MaxCardsInStudySet).TwoWay();
			set.Bind (MaxNumberOfCardsText).To (ViewModel => ViewModel.MaxCardsInStudySet).TwoWay();

			set.Bind (ShowCharactersFirstSwitch).To (ViewModel => ViewModel.CharactersFirst).TwoWay();
			set.Bind (ShowPinyinFirstSwitch).To (ViewModel => ViewModel.PinyinFirst).TwoWay();
			set.Bind (ShowDefinitionFirstSwitch).To (ViewModel => ViewModel.EnglishFirst).TwoWay();

			set.Bind (ShowDefinitionSwitch).To (ViewModel => ViewModel.Settings.ShowDefinition).TwoWay();
			set.Bind (ShowSimplifiedSwitch).To (ViewModel => ViewModel.Settings.ShowSimplified).TwoWay();
			set.Bind (ShowTraditionalSwitch).To (ViewModel => ViewModel.Settings.ShowTraditional).TwoWay();
			set.Bind (ShowPinyinSwitch).To (ViewModel => ViewModel.Settings.ShowPinyin).TwoWay();

			set.Bind (MaxCardsSlider).To (ViewModel => ViewModel.MaxCardsInStudySet).TwoWay ();

	//		set.Bind (SelectedSetNameLabel).To (ViewModel => ViewModel.SelectedSet.SetName);




			set.Apply ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			ViewModel.SaveSettings(0);//id prefer to use icommand execute but it doesn't seem to be able to http://stackoverflow.com/questions/18366340/mvvmcross-get-this-error-after-upgrade-to-monotouch-version-3-2-1

		}
	}
}

