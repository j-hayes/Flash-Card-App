using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;

using FlashCardApp.Core.Managers;
using System;

namespace FlashCardApp.Core.ViewModels.Study
{
    public class CloudCardSaveViewModel : MvxViewModel
    {
        private IFlashCardManager _flashCardManager;

        private readonly MvxSubscriptionToken _flashCardSetSubscriptionToken;

        public CloudCardSaveViewModel(IFlashCardManager flashCardManager)
        {
            _flashCardManager = flashCardManager;
           

        }

        public class Nav
        {
            public string UserEmail { get; set; }
            public string Password { get; set; }

        }
        public void Init(Nav navigation)
        {
            UserName = navigation.UserEmail;
            Password = navigation.Password;
            ShowSaveReplaceCardsButton = false;
       
        }

        

        private bool LoggedIn { get; set; }

        private string UserName { get; set; }
        private string Password { get; set; }

        public LoginViewModel LoginViewModel
        {
            get { return _loginViewModel; }
            set { _loginViewModel = value; }
        }

        public FlashCardSet SelectedFlastCardSet
        {
            get { return _selectedFlastCardSet; }
            set { _selectedFlastCardSet = value; RaisePropertyChanged(() => SelectedFlastCardSet); }
        }

        private List<FlashCardSet> _flashCardSets;
        public List<FlashCardSet> FlashCardSets
        {
            get { return _flashCardSets; }
            set
            {
                _flashCardSets = value;
                RaisePropertyChanged(() => FlashCardSets);
            }
        }

        private string _response;
        private FlashCardSet _selectedFlastCardSet;
        private bool _showSaveReplaceCardsButton;
        private LoginViewModel _loginViewModel;

        public string ResponseText
        {
            get { return _response; }
            set { _response = value; RaisePropertyChanged(()=> ResponseText); }
        }

        public bool ShowSaveReplaceCardsButton
        {
            get { return _showSaveReplaceCardsButton; }
            set { _showSaveReplaceCardsButton = value; RaisePropertyChanged(() => ShowSaveReplaceCardsButton); }
        }

        public ICommand GetCloudCards {
            get
            {
				throw new NotImplementedException ();
            }
        }

     
       

        public ICommand ReplaceCardsWithCloudCards
        {
            get {return new MvxCommand(DoReplaceWithCloudCards);}

        }

        private void DoReplaceWithCloudCards()
        {
            if (FlashCardSets != null)
            {
                _flashCardManager.ReplaceCardsWithCloudCards(FlashCardSets);
                ResponseText = "your cards have been successfully downloaded.";
            }
        }

        public ICommand UploadCardsToCloud
        {
			get{throw new NotImplementedException ();}
        }
	}
}