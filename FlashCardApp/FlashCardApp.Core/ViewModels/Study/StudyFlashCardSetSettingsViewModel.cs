using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using FlashCardApp.Core.Services;

namespace FlashCardApp.Core.ViewModels.Study
{
    //todo this is super broken. 
    public enum ShowSideFirstSetting
    {
        English,
        Characters,
        Pinyin
    }



    public class StudyFlashCardSetSettingsViewModel : MvxViewModel
    {
        private IMvxMessenger _messenger;
        private IFlashCardManager _manager;
        private readonly MvxSubscriptionToken _token;
        private IStudySettingsService _settingsService;




        public StudyFlashCardSetSettingsViewModel(IMvxMessenger messenger, IFlashCardManager manager, IStudySettingsService settingsService)
        {
            _messenger = messenger;
            _manager = manager;
            _settingsService = settingsService;
            _settings = _settingsService.GetStudySettings();
          
            SetList = CreateSetList(manager.GetSetList());
           
            //   _token = _messenger.Subscribe<SelectedSetChangedMessage>();
            /*_showDefinition = true;
            _showPinyin = true;
          
            _canShowCharacters = true;
         */
        }

        private List<WithCommand<FlashCardSet>> CreateSetList(List<FlashCardSet> getSetList)
        {
            List<WithCommand<FlashCardSet>> sets = new List<WithCommand<FlashCardSet>>();
            foreach (var flashCardSet in getSetList)
            {
                FlashCardSet set = flashCardSet;
                sets.Add(new WithCommand<FlashCardSet>(flashCardSet, new MvxCommand(()=>NavigateToStudyViewModel(set.ID))));
            }
            return sets;
        }



        private StudySettings _settings;
        public StudySettings Settings
        {
            get { return _settings; }
            set
            {
                _settings = value;
                RaisePropertyChanged(() => Settings);
                //  _settingsService.SetStudySettings(_settings);
            }
        }

        public bool CanShowCharacters
        {
            get
            {
                return Settings.ShowSimplified || Settings.ShowTraditional;
            }

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
            set
            {
                _firstSide = value;
                RaisePropertyChanged(() => FirstSide);
            }

        }

        private bool _pinyinFirst;
        public bool PinyinFirst
        {
            get { return _pinyinFirst; }
            set
            {
                _pinyinFirst = value;
                if (value)
                {
                    UpdateShowFirstSetting("Pinyin");
                }
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
                if (value)
                {
                    UpdateShowFirstSetting("Characters");
                } //todo this should be a global enum. oh it is the windows version is the problems refactor it
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
                if (value)
                {
                    UpdateShowFirstSetting("Definition");
                }
                RaisePropertyChanged(() => EnglishFirst);
            }
        }




        public void UpdateShowFirstSetting(string sideString)
        {
            _pinyinFirst = false;
            _charactersFirst = false;
            _englishFirst = false;
            switch (sideString)
            {
                case "Pinyin":
                    _pinyinFirst = true;
                    Settings.FirstSide = "Pinyin";
                    break;
                case "Characters":
                    _charactersFirst = true;
                    Settings.FirstSide = "Characters";
                    break;
                case "Definition":
                    _englishFirst = true;
                    Settings.FirstSide = "Definition";
                    break;
                default:
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
       

        public void SaveSettings(int selectedSetId)
        {
            _settingsService.SetStudySettings(Settings);
            _settingsService.SetSelectedSetId(selectedSetId);
        }

        private void NavigateToStudyViewModel(int id)
        {
            
            Settings.SelectedSetId = id;
            SaveSettings(id);
            NavigateToStudyViewModel();

        }
        private void NavigateToSetList()
        {
      
            ShowViewModel<FlashCardSetListViewModel>();
        }

        public ICommand StudySetCommand
        {
            get { return new MvxCommand(NavigateToStudyViewModel); }
        }

        private void NavigateToStudyViewModel()
        {
            ShowViewModel<StudyFlashCardSetViewModel>();

        }
        private MvxCommand _updateShowCommand;
        public ICommand UpdateShowCommand
        {
            get
            {
                _updateShowCommand = _updateShowCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(UpdateShow);
                return _updateShowCommand;
            }
        }

        private List<WithCommand<FlashCardSet>> _setList;
        public List<WithCommand<FlashCardSet>> SetList
        {
            get { return _setList; }
            set
            {
                _setList = value;
                RaisePropertyChanged(() => SetList);
            }
        }



        private void UpdateShow()
        {
            RaisePropertyChanged(() => CanShowCharacters);
        }

        #endregion

    }
}
