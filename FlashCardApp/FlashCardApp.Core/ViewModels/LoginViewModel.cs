using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.FlashCardService;

namespace FlashCardApp.Core.ViewModels
{
    class LoginViewModel :MvxViewModel
    {
        

        public LoginViewModel()
        {
        }
        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; RaisePropertyChanged(()=>UserEmail); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }

        public ICommand LoginCommand
        {
            get {return new MvxCommand(DoLogin);
            }

        }

        private void DoLogin()
        {
            FlashCardServiceClient client = new FlashCardServiceClient();
            
        }
    }
}
