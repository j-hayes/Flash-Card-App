using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.FlashCardService;
using FlashCardApp.Core.Managers;

namespace FlashCardApp.Core.ViewModels.Study
{
    public class CloudCardSaveViewModel : MvxViewModel
    {
        private IFlashCardManager _flashCardManager;

        private FlashCardServiceClient serviceClient;
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
            DoGetCloudCards();//Todo: Refactor out these into new manager or the FCM

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
                return new MvxCommand(DoGetCloudCards);
            }
        }

        private void DoGetCloudCards()
        {
            serviceClient = new FlashCardServiceClient();
            serviceClient.OpenAsync();
            serviceClient.OpenCompleted += ServiceClientOnOpenCompletedForDownload;
           
      

            
        }

        private void ServiceClientOnOpenCompletedForDownload(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
        {
            serviceClient.GetSetsCompleted += ClientOnGetSetsCompleted;
            serviceClient.GetSetsAsync(new GetSetsRequest(UserName, Password));
        }

        private void ClientOnGetSetsCompleted(object sender, GetSetsCompletedEventArgs getSetsCompletedEventArgs)
        {
            if (getSetsCompletedEventArgs.Error != null)
            {
                ResponseText = getSetsCompletedEventArgs.Error.Message;
            }
            else if (getSetsCompletedEventArgs.Cancelled)
            {
                ResponseText = "The operation was canceled please try again";
            }
            else
            {
                List<ServiceFlashCardSet> sets = getSetsCompletedEventArgs.Result.GetSetsResult.ToList();
                serviceClient.OpenCompleted -= ServiceClientOnOpenCompletedForDownload;
                serviceClient.CloseAsync();
                ServiceCardConverter serviceCardConverter = new ServiceCardConverter();
                FlashCardSets =  serviceCardConverter.ConvertCloudSetToSet(sets);
                ShowSaveReplaceCardsButton = true;
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
            get{return new MvxCommand(DoUploadCardsToCloud);}
        }

        private void DoUploadCardsToCloud()
        {
            serviceClient = new FlashCardServiceClient();
            serviceClient.OpenAsync();
            serviceClient.UploadSetsCompleted += ClientOnUploadSetsCompleted;

            serviceClient.UploadSetsAsync(new UploadSetsRequest(_flashCardManager.GetCloudSetsForUpload(),
                UserName, Password));
            serviceClient.CloseAsync();
        }

        private void ClientOnUploadSetsCompleted(object sender, UploadSetsCompletedEventArgs uploadSetsCompletedEventArgs)
        {
            if (uploadSetsCompletedEventArgs.Error != null)
            {
                ResponseText = uploadSetsCompletedEventArgs.Error.Message;
            }
            else if (uploadSetsCompletedEventArgs.Cancelled)
            {
                ResponseText = "The operation was canceled please try again";
            }
            else
            {
                if (uploadSetsCompletedEventArgs.Result.UploadSetsResult)
                {
                    ResponseText = "Your Cards Have been uploaded successfully";
                }
                else
                {
                    ResponseText = "There was an error";
                }
            }
        }
    }
}