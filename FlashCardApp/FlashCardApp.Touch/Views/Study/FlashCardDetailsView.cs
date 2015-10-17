
using System;
using CoreGraphics;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using FlashCardApp.Core.ViewModels.Study;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace FlashCardApp.Touch
{
	public partial class FlashCardDetailsView : MvxViewController
	{
		private UIView activeview;             // Controller that activated the keyboard
		private float scroll_amount = 0.0f;    // amount to scroll 
		private float bottom = 0.0f;           // bottom point
		private float offset = 10.0f;          // extra offset
		private bool moveViewUp = false;           // which direction are we moving
		private float _moveTextBoxY = 0.0f;


		public FlashCardDetailsView () : base ("FlashCardDetailsView", null)
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
			activeview = this.View;

		
			this.View.AddSubview (InputScrollView);

			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardWillShow);
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardWillHide);



			var set = this.CreateBindingSet<FlashCardDetailsView, FlashCardDetailsViewModel> ();

			set.Bind (SimplifiedTextField).To (x => x.Card.Simplified);
			set.Bind (SimplifiedTextField).For("Enabled").To (x => x.EditModeOff);

			set.Bind (TraditionalTextField).To(x=>x.Card.Traditional);
			set.Bind (TraditionalTextField).For("Enabled").To (x => x.EditModeOff);

			set.Bind (PinyinTextField).To(x=>x.Card.AccentedPinyin);
			set.Bind (PinyinTextField).For("Enabled").To (x => x.EditModeOff);

			set.Bind (DefinitionTextView).To (x => x.Card.Definition);
			set.Bind (DefinitionTextView).For("Editable").To (x => x.EditModeOff);

			set.Bind (EditModeSwitch).To (x => x.EditModeOff).TwoWay();

			set.Bind (SaveCardButton).To ("UpdateCardCommand");

			set.Apply ();



			var gesture = new UITapGestureRecognizer(() =>
				{
					SimplifiedTextField.ResignFirstResponder();
					TraditionalTextField.ResignFirstResponder();
					PinyinTextField.ResignFirstResponder();
					DefinitionTextView.ResignFirstResponder();

				});
			gesture.CancelsTouchesInView = false;

			View.AddGestureRecognizer(gesture);
		}

		private void OnKeyboardWillShow (NSNotification notification)
		{
			throw new NotImplementedException ();

//			var keyboardObject = notification.UserInfo.ValueForKey(new NSString("UIKeyboardFrameEndUserInfoKey"));
//			var keyboardRect = new NSValue(keyboardObject.Handle).RectangleFValue;
//			var keyboardY = keyboardRect.Y;
//			var textBoxViewBottom = InputScrollView.Frame.Height;
//			if (keyboardY < textBoxViewBottom)
//			{
//				_moveTextBoxY = textBoxViewBottom - keyboardY + 10;
//				UIView.Animate(0.3, () => {
//					var frame = new CGRect(InputScrollView.Frame.X, InputScrollView.Frame.Y - _moveTextBoxY, InputScrollView.Frame.Width, 
//						InputScrollView.Frame.Height);
//					InputScrollView.Frame = frame;
//				});
//
//			}
		}

		private void OnKeyboardWillHide(NSNotification notification)
		{
			throw new NotImplementedException ();
//			// View has moved
//			if (_moveTextBoxY != 0)
//			{
//				UIView.Animate(0.3, () => {
//					var frame = new CGRect(InputScrollView.Frame.X, InputScrollView.Frame.Y + _moveTextBoxY, 
//						InputScrollView.Frame.Width, InputScrollView.Frame.Height);
//					InputScrollView.Frame = frame;
//				});
//			}
		}
	}
}

