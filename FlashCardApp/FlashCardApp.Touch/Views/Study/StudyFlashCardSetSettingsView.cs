
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using Cirrious.MvvmCross.Binding.BindingContext;
using FlashCardApp.Core.ViewModels.Study;

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






			var set = this.CreateBindingSet<StudyFlashCardSetSettingsView, StudyFlashCardSetSettingsViewModel> ();

			set.Bind (MaxNumberOfCardsScroller).To (ViewModel => ViewModel.MaxCardsInStudySet).TwoWay();
			set.Bind (MaxNumberOfCardsText).To (ViewModel => ViewModel.MaxCardsInStudySet).TwoWay();

			set.Bind (ShowCharactersFirstSwitch).To (ViewModel => ViewModel.CharactersFirst).TwoWay();
			set.Bind (ShowPinyinFirstSwitch).To (ViewModel => ViewModel.PinyinFirst).TwoWay();
			set.Bind (ShowDefinitionFirstSwitch).To (ViewModel => ViewModel.EnglishFirst).TwoWay();

			set.Bind (ShowDefinitionSwitch).To (ViewModel => ViewModel.ShowDefinition).TwoWay();
			set.Bind (ShowSimplifiedSwitch).To (ViewModel => ViewModel.ShowSimplified).TwoWay();
			set.Bind (ShowTraditionalSwitch).To (ViewModel => ViewModel.ShowTraditional).TwoWay();
			set.Bind (ShowPinyinSwitch).To (ViewModel => ViewModel.ShowPinyin).TwoWay();


			set.Bind (SubmitButton).To ("SubmitSettingsCommand");


			set.Apply ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

