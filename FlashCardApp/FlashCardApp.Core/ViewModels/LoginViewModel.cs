using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Messages;
using FlashCardApp.Core.ViewModels.Study;
using System;

namespace FlashCardApp.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {

        private readonly IMvxMessenger _messenger;

        public LoginViewModel(IMvxMessenger messenger)
        {
            _messenger = messenger;
            IsUserNotLoggedIn = true;
        }
        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                RaisePropertyChanged(() => UserEmail);
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(()=> ErrorMessage);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private string _verifyPassword;

        public string VerifyPassword
        {
            get { return _verifyPassword; }
            set { _verifyPassword = value; }
        }

        private bool _isUserNotLoggedIn;
        public bool IsUserNotLoggedIn
        {
            get { return _isUserNotLoggedIn; }
            set
            {
                _isUserNotLoggedIn = value;
                RaisePropertyChanged(() => IsUserNotLoggedIn);
              
            }
        }

        public ICommand LoginCommand
        {
            get
            {
				throw new NotImplementedException ();
            }

        }

     
        public ICommand CreateUserAccountCommand
        {
			get{throw new NotImplementedException();}
        }

        public ICommand CancelCommand
        {
            get { return new MvxCommand(DoCancelCommand); }
        }

        private void DoCancelCommand()
        {
            Close(this);
            ShowViewModel<HomePageViewModel>();
        }
    }
}
