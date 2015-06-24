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
using Cirrious.MvvmCross.WindowsCommon.Views;
using FlashCardApp.Core.ViewModels.Study;
using FlashCardApp.Store.Common;

namespace FlashCardApp.Store.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class StudyFlashCardSetView : MvxWindowsPage
    {
        public StudyFlashCardSetView()
        {
            this.InitializeComponent();
        }

        public StudyFlashCardSetViewModel viewModel
        {
            get { return (StudyFlashCardSetViewModel)base.ViewModel; }
        }

        #region properties

        private double TouchDownX { get; set; }
        private double TouchDownY { get; set; }


        #endregion

       

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

        private void PreviousCardTap(object sender, TappedRoutedEventArgs e)
        {
           PreviousCard();
        }

        private void FlipCardLeftTap(object sender, TappedRoutedEventArgs e)
        {
            FlipCardLeft();
        }

        private void FlipCardRightTap(object sender, TappedRoutedEventArgs e)
        {
            FlipCardRight();
        }
        
        private void NextCardIncorrectTap(object sender, TappedRoutedEventArgs e)
        {
            NextCardIncorrect();
        }

        private void NextCardCorrectTap(object sender, TappedRoutedEventArgs e)
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

        private void SkipCardTap(object sender, TappedRoutedEventArgs e)
        {
            ((StudyFlashCardSetViewModel)ViewModel).CorrectNextCardCommand.Execute(null);//todo add skip card command
        }
    }
}
