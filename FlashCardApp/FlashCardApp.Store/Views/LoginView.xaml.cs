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
using FlashCardApp.Core.ViewModels;
using FlashCardApp.Store.Common;

namespace FlashCardApp.Store.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class LoginView : MvxWindowsPage
    {
        public LoginView()
        {
            this.InitializeComponent();
            StateIsCreateAccount = false;
        }
        bool StateIsCreateAccount { get; set; }

    
        private void ToggleCreateAccountButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (StateIsCreateAccount)
            {
                VerifyPasswordBlock.Visibility = Visibility.Collapsed;
                VerfiyPasswordTextBox.Visibility = Visibility.Collapsed;
                ToggleCreateAccountButton.Content = "Create Account";
                StateIsCreateAccount = false;
            }
            else
            {
                VerifyPasswordBlock.Visibility = Visibility.Visible;
                VerfiyPasswordTextBox.Visibility = Visibility.Visible;
                ToggleCreateAccountButton.Content = "Cancel";

                StateIsCreateAccount = true;


            }
        }

        private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (StateIsCreateAccount)
            {
                ((LoginViewModel)ViewModel).CreateUserAccountCommand.Execute(null);
            }
            else
            {
                ((LoginViewModel)ViewModel).LoginCommand.Execute(null);
            }
        }
    }
}
