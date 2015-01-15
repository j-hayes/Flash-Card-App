using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using FlashCardApp.Core.Managers.FlashCardApp.Core.Services;
using FlashCardApp.Core.Services;
using FlashCardApp.Core.ViewModels.Dictionary;
using FlashCardApp.Core.ViewModels.Random;
using FlashCardApp.Core.ViewModels.Study;

namespace FlashCardApp.Core.ViewModels
{
   public class HomePageViewModel : MvxViewModel
    {

       public HomePageViewModel(IDictionarySearchManager dictionarySearchManager, IFlashCardManager flashCardManager, IMvxMessenger messenger, IStudySettingsService settingsService)
       {
           DictionaryViewModel = new DictionaryViewModel(dictionarySearchManager, flashCardManager);
           StudyFlashCardSetSettingsViewModel = new StudyFlashCardSetSettingsViewModel(messenger, flashCardManager,
               settingsService);
           StudyFlashCardSetSettingsViewModel  = new StudyFlashCardSetSettingsViewModel(messenger,flashCardManager,settingsService);
       }

       public DictionaryViewModel DictionaryViewModel
       {
           get { return _dictionaryViewModel; }
           set { _dictionaryViewModel = value;RaisePropertyChanged(()=>DictionaryViewModel); }
       }


       private StudyFlashCardSetSettingsViewModel _studyFlashCardSetSettingsViewModel;
       public StudyFlashCardSetSettingsViewModel StudyFlashCardSetSettingsViewModel
       {
           get { return _studyFlashCardSetSettingsViewModel; }
           set
           {
               _studyFlashCardSetSettingsViewModel = value;
               RaisePropertyChanged(() => StudyFlashCardSetSettingsViewModel);
           }
       }


       private StudyFlashCardSetViewModel _studyViewModel;
       public StudyFlashCardSetViewModel StudyViewModel
       {
           get { return _studyViewModel; }
           set
           {
               _studyViewModel = value;
               RaisePropertyChanged(() => StudyViewModel);
           }
       }

       private RandomResultViewModel _randomResultViewModel;
       public RandomResultViewModel RandomResultViewModel
       {
           get { return _randomResultViewModel; }
           set
           {
               _randomResultViewModel = value;
               RaisePropertyChanged(() => RandomResultViewModel);
           }
       }
       
       private string _searchTerm = "";
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value; RaisePropertyChanged(() => SearchTerm);
            }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _dictionaryCommand;
        public ICommand DictionaryCommand
        {
            get
            {
                _dictionaryCommand = _dictionaryCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(NavigateToDictionary);
                return _dictionaryCommand;
            }
        }
        private void NavigateToDictionary()
        {
            ShowViewModel<DictionaryViewModel>();
        }
        
        private MvxCommand _flashCardCommand;
        public ICommand FlashCardCommand
        {
            get
            {
                _flashCardCommand = _flashCardCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(NavigateToStudyFlashCardSetSettings);
                return _flashCardCommand;
            }
        }

      

      

        
        private void NavigateToStudyFlashCardSetSettings()
        {
            ShowViewModel<StudyFlashCardSetSettingsViewModel>();
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _saveCardCloudCommand;
       private DictionaryViewModel _dictionaryViewModel;

       public ICommand SaveCardCloudCommand
        {
            get
            {
                _saveCardCloudCommand = _saveCardCloudCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(NavigateToCloudCardSave);
                return _saveCardCloudCommand;
            }
        }

        private void NavigateToCloudCardSave()
        {
            ShowViewModel<LoginViewModel>();
        }
    }
}
