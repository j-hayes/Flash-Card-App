using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.FlashCardService;
using FlashCardApp.Core.Messages;
using FlashCardApp.Core.ViewModels.Study;

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
                return new MvxCommand(DoLogin);
            }

        }

        private void DoLogin()
        {
            FlashCardServiceClient client = new FlashCardServiceClient();
            if (!string.IsNullOrEmpty(UserEmail) & !string.IsNullOrEmpty(Password))
            {
                client.VerifyUserCompleted += ClientOnVerifyUserCompleted;
                client.VerifyUserAsync(new VerifyUserRequest(UserEmail, Password));
            }
            else
            {
                ErrorMessage = "All fields must be filled";
            }

        }

        private void ClientOnVerifyUserCompleted(object sender,
            VerifyUserCompletedEventArgs verifyUserCompletedEventArgs)
        {

            if (verifyUserCompletedEventArgs.Error != null)
            {
                ErrorMessage =
                    "There is no account with that email and password combination, please verify and try again";
                IsUserNotLoggedIn = true;
            }

            else if (verifyUserCompletedEventArgs.Result.VerifyUserResult)
            {
                IsUserNotLoggedIn = false;
                _messenger.Publish(new UserLoggedInMessage(this));
                Close(this);
                ShowViewModel<CloudCardSaveViewModel>(new CloudCardSaveViewModel.Nav()
                {
                    Password = this.Password,
                    UserEmail = this.UserEmail
                });
            }

        }

        public ICommand CreateUserAccountCommand
        {
            get { return new MvxCommand(DoCreateUserAccount); }
        }

        private void DoCreateUserAccount()
        {
            FlashCardServiceClient client = new FlashCardServiceClient();
            if (!string.IsNullOrEmpty(UserEmail) & !string.IsNullOrEmpty(Password) & !string.IsNullOrEmpty(VerifyPassword)) 
            {
                if (VerifyPassword == Password)
                {
                    client.CreateUserCompleted += ClientOnCreateUserCompleted;
                    client.CreateUserAsync(new CreateUserRequest(UserEmail, Password));
                }
                else
                {
                    ErrorMessage = "Password and verify password must match.";
                }
            }
            else
            {
                ErrorMessage = "All fields must be filled";
            }
        }

        private void ClientOnCreateUserCompleted(object sender,
            CreateUserCompletedEventArgs createUserCompletedEventArgs)
        {
            if (createUserCompletedEventArgs.Error != null)
            {
                ErrorMessage = createUserCompletedEventArgs.Error.Message;
            }
            else if (createUserCompletedEventArgs.Result.CreateUserResult == true)
            {
                IsUserNotLoggedIn = false;
                _messenger.Publish(new UserLoggedInMessage(this));
                Close(this);
                ShowViewModel<CloudCardSaveViewModel>(new CloudCardSaveViewModel.Nav()
                {
                    Password = this.Password,
                    UserEmail = this.UserEmail
                });
            }
            else
            {
                ErrorMessage = "There was an error creating your account please try again";
            }
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
