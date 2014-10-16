using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using FlashCardApp.Core.Messages;
using FlashCardApp.Core.Services;

namespace FlashCardApp.Core.ViewModels.Study
{

    public enum ShowSideFirstSetting
    {
        English,
        Characters,
        Pinyin
    }

 
   
    public class StudyFlashCardSetSettingsViewModel : MvxViewModel
    {
        private  IMvxMessenger _messenger;
        private IFlashCardManager _manager;
        private readonly MvxSubscriptionToken _token;
        private IStudySettingsService _settingsService;
      
       


        public StudyFlashCardSetSettingsViewModel(IMvxMessenger messenger, IFlashCardManager manager, IStudySettingsService settingsService)
        {
            _messenger = messenger;
            _manager = manager;
            _settingsService = settingsService;
            _settings = _settingsService.GetStudySettings();
            _selectedSet = manager.GetSet(settingsService.GetSelectedSetId());
            _selectedSet.FlashCards = manager.GetCardsForSet(_selectedSet.ID);
            //   _token = _messenger.Subscribe<SelectedSetChangedMessage>();
            /*_showDefinition = true;
            _showPinyin = true;
            _showTraditional = true;
            _showSimplified = true;
            _canShowCharacters = true;
         */
        }




        private StudySettings _settings;
        public StudySettings Settings
        {
            get { return _settings; }
            set
            {
                _settings = value;
                RaisePropertyChanged(()=>Settings);
                _settingsService.SetStudySettings(_settings);
            }
        }

        private FlashCardSet _selectedSet;
        public FlashCardSet SelectedSet
        {
            get { return _selectedSet; }
            set
            {
               
                _selectedSet = value;
                RaisePropertyChanged(()=>SelectedSet);
             
            }
        }


         private bool _canShowCharacters;
        public bool CanShowCharacters
        {
            get { return _canShowCharacters; }
            private set { _canShowCharacters = value; RaisePropertyChanged(()=>CanShowCharacters);}
        }

        private int _maxCardsInStudySet;
        public int MaxCardsInStudySet
        {
            get { return _maxCardsInStudySet; }
            set { _maxCardsInStudySet = value; RaisePropertyChanged(() => MaxCardsInStudySet); }
        }

        private ShowSideFirstSetting _firstSide;
        public ShowSideFirstSetting FirstSide
        {
            get { return _firstSide; }
            set {
				_firstSide = value; 
				RaisePropertyChanged(()=>FirstSide); }

        }

        private bool _pinyinFirst;
        public bool PinyinFirst
        {
            get { return _pinyinFirst; }
            set
            {
                _pinyinFirst = value;
				UpdateShowFirstSetting("Pinyin");
                RaisePropertyChanged(() => PinyinFirst);
            }

        }

        private bool _charactersFirst;
        public bool CharactersFirst
        {
            get { return _charactersFirst; }
            set
            {
                _charactersFirst = value;
				UpdateShowFirstSetting("Characters");//todo this should be a global enum. oh it is the windows version is the problems refactor it
                RaisePropertyChanged(() => CharactersFirst);

            }
        }

        private bool _englishFirst;
        public bool EnglishFirst
        {
            get { return _englishFirst; }
            set
            {
                _englishFirst = value;
				UpdateShowFirstSetting("English");
                RaisePropertyChanged(() => EnglishFirst);
            }
        }
        
       


        public void UpdateShowFirstSetting(string sideString)
        {
            PinyinFirst = false;
            CharactersFirst = false;
            EnglishFirst = false;
            if (sideString == "Pinyin")
            {
                PinyinFirst = true;
                Settings.FirstSide = "Pinyin";
            }
            else if (sideString == "Characters")
            {
                CharactersFirst = true;
                Settings.FirstSide = "Characters";
            }
            else if (sideString == "Definition")
            {
                EnglishFirst = true;
                Settings.FirstSide = "Definition";
            }
            else
            {
                throw new NotSupportedException(
                    "The side string is incorrect choices are Definition, Characters, or Pinyin");
            }
            RaiseAllPropertiesChanged();
        }

        #region commands
        public ICommand NavigateToSetListCommand
        {
            get
            {
                return new MvxCommand(NavigateToSetList);
            }
        }
		public ICommand SaveSettingsCommand{
			get{
				return new MvxCommand (SaveSettings);
			}
		}

		public void SaveSettings ()
		{
			_settingsService.SetStudySettings (Settings);
			_settingsService.SetSelectedSetId (SelectedSet.ID);
		}

        private void NavigateToSetList()
        {
			SaveSettings ();
            ShowViewModel<FlashCardSetListViewModel>();
        }

        public ICommand StudySetCommand {
            get {return new MvxCommand(NavigateToStudyViewModel); }
        }

        private void NavigateToStudyViewModel()
        {
			SaveSettings ();
            ShowViewModel<StudyFlashCardSetViewModel>();

        }


        #endregion 

    }
}
