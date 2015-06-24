using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Windows.UI.Input;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FlashCardApp.Core.ViewModels.Dictionary;
using FlashCardApp.Core.ViewModels.Study;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;
using ManipulationCompletedEventArgs = System.Windows.Input.ManipulationCompletedEventArgs;
using ManipulationStartedEventArgs = System.Windows.Input.ManipulationStartedEventArgs;

namespace FlashCardApp.WindowsPhone.Views.Study
{
    public partial class StudyFlashCardSetView : MvxPhonePage
    {
        public StudyFlashCardSetView()
        {
            InitializeComponent();
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
            ((StudyFlashCardSetViewModel)ViewModel).CorrectNextCardCommand.Execute(new object());
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

        
        private void FlipCardLeftTap(object sender, GestureEventArgs e)
        {
            FlipCardLeft();
        }

        private void FlipCardRightTap(object sender, GestureEventArgs e)
        {
            FlipCardRight();
        }

        private void NextCardIncorrectTap(object sender, GestureEventArgs e)
        {
            NextCardIncorrect();
        }

        private void NextCardCorrectTap(object sender, GestureEventArgs e)
        {
            NextCardCorrect();
        }

        
        private void CenterGrid_ManipulateStarted(object sender, ManipulationStartedEventArgs manipulationStartedEventArgs)
        {
            TouchDownX = manipulationStartedEventArgs.ManipulationOrigin.X;
            TouchDownY = manipulationStartedEventArgs.ManipulationOrigin.Y;
    
        }

        private void CenterGrid_ManipulateCompleted(object sender, ManipulationCompletedEventArgs manipulationCompletedEventArgs)
        {
            double deltaX = TouchDownX - manipulationCompletedEventArgs.ManipulationOrigin.X;
            double deltaY = TouchDownY - manipulationCompletedEventArgs.ManipulationOrigin.Y;

            double absX = Math.Abs(TouchDownX - manipulationCompletedEventArgs.ManipulationOrigin.X);
            double absY = Math.Abs(TouchDownY - manipulationCompletedEventArgs.ManipulationOrigin.Y);

            if (absX > absY) //left or right
            {
                if (deltaX > 0 & deltaX > 12) //right
                {
                    ((StudyFlashCardSetViewModel)ViewModel).FlipCardRightCommand.Execute(null);
                }
                else if (deltaX < -12) //left
                {
                    ((StudyFlashCardSetViewModel)ViewModel).FlipCardLeftCommand.Execute(null);
                }
            }
            else // up or down
            {
                if (deltaY > 0 & deltaY > 12) //up
                {
                    ((StudyFlashCardSetViewModel)ViewModel).CorrectNextCardCommand.Execute(null);
                }
                else if (deltaY < -12) //down
                {
                    ((StudyFlashCardSetViewModel)ViewModel).IncorrectNextCardCommand.Execute(null);
                }
            }

        }

      


        private void UIElement_OnManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UIElement_OnTap(object sender, GestureEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}