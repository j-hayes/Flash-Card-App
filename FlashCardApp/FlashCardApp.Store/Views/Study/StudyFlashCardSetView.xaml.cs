using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using FlashCardApp.Core.ViewModels.Study;
using FlashCardApp.Store.Common;

namespace FlashCardApp.Store.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class StudyFlashCardSetView : FlashCardApp.Store.Common.LayoutAwarePage
    {
        public StudyFlashCardSetView()
        {
            this.InitializeComponent();
        }

        #region properties

        private double TouchDownX { get; set; }
        private double TouchDownY { get; set; }


        #endregion

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void NextCardCorrect()
        {
            ((StudyFlashCardSetViewModel) ViewModel).CorrectNextCardCommand.Execute(new object());
        }

        private void NextCardIncorrect()
        {
            ((StudyFlashCardSetViewModel)ViewModel).IncorrectNextCardCommand.Execute(new object());
        }

        private void FlipCardLeft()
        {
            ((StudyFlashCardSetViewModel)ViewModel).FlipCardLeftCommand.Execute(new object());
        }

        private void PreviousCard()
        {
            ((StudyFlashCardSetViewModel)ViewModel).PreviousCardCardCommand.Execute(new object());
        }

        private void FlipCardRight()
        {
            ((StudyFlashCardSetViewModel)ViewModel).FlipCardRightCommand.Execute(new object());
        }

        private void TopButton_OnTapped(object sender, TappedRoutedEventArgs e)
        {
           PreviousCard();
        }

        private void LeftButton_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            FlipCardLeft();
        }

        private void RightButton_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            FlipCardRight();
        }
        
        private void BottomLeft_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            NextCardIncorrect();
        }

        private void BottomRight_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            NextCardCorrect();
        }

        private void Grid_Drag(object sender, DragEventArgs e)
        {
        }

        private void CenterGrid_ManipulateStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            TouchDownX = e.Position.X;
            TouchDownY = e.Position.Y;
        }

        private void CenterGrid_ManipulateCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            double deltaX = TouchDownX - e.Position.X;
            double deltaY = TouchDownY - e.Position.Y;

            double absX = Math.Abs(TouchDownX - e.Position.X);
            double absY = Math.Abs(TouchDownY - e.Position.Y);

            if (absX > absY) //left or right
            {
                if (deltaX > 0 & deltaX > 12) //right
                {
                    ((StudyFlashCardSetViewModel) ViewModel).FlipCardRightCommand.Execute(null);
                }
                else if (deltaX < -12) //left
                {
                    ((StudyFlashCardSetViewModel) ViewModel).FlipCardLeftCommand.Execute(null);
                }
            }
            else // up or down
            {
                if (deltaY> 0 & deltaY > 12) //up
                {
                    ((StudyFlashCardSetViewModel) ViewModel).CorrectNextCardCommand.Execute(null);
                }
                else if (deltaY < -12) //down
                {
                    ((StudyFlashCardSetViewModel) ViewModel).IncorrectNextCardCommand.Execute(null);
                }
            }

        }
    }
}
