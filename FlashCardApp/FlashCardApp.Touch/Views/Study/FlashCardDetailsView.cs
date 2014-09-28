
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
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


			NSNotificationCenter.DefaultCenter.AddObserver
			(UIKeyboard.DidShowNotification,KeyBoardUpNotification);

			// Keyboard Down
			NSNotificationCenter.DefaultCenter.AddObserver
			(UIKeyboard.WillHideNotification,KeyBoardDownNotification);



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

		private void ScrollTheView(bool move)
		{

			// scroll the view up or down
			UIView.BeginAnimations (string.Empty, System.IntPtr.Zero);
			UIView.SetAnimationDuration (0.3);

			RectangleF frame = View.Frame;

			if (move) {
				frame.Y -= scroll_amount;
			} else {
				frame.Y += scroll_amount;
				scroll_amount = 0;
			}

			View.Frame = frame;
			UIView.CommitAnimations();
		}

		private void KeyBoardDownNotification(NSNotification notification)
		{
			var val = new NSValue(notification.UserInfo.ValueForKey(UIKeyboard.FrameBeginUserInfoKey).Handle);
			RectangleF keyboard = val.RectangleFValue;
			if(moveViewUp){ScrollTheView(false);}
		}

		private void KeyBoardUpNotification(NSNotification notification)
		{
			// get the keyboard size
			var val = new NSValue(notification.UserInfo.ValueForKey(UIKeyboard.FrameBeginUserInfoKey).Handle);
			RectangleF keyboard = val.RectangleFValue;

			// Find what opened the keyboard
			foreach (UIView view in this.View.Subviews[0].Subviews) {
				if (view.IsFirstResponder)
					activeview = view;
			}

		

			// Bottom of the controller = initial position + height + offset      
			bottom = (activeview.Frame.Y + activeview.Frame.Top + offset);

			// Calculate how far we need to scroll
			scroll_amount = (keyboard.Height - (View.Frame.Size.Height - bottom)) ;

			// Perform the scrolling
			if (scroll_amount > 0) {
				moveViewUp = true;
				ScrollTheView (moveViewUp);
			} else {
				moveViewUp = false;
			}

		}
	}
}

