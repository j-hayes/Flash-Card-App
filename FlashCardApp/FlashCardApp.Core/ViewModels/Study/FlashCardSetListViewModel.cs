using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;

namespace FlashCardApp.Core.ViewModels.Study
{
    public class FlashCardSetListViewModel : MvxViewModel
    {
        private readonly IFlashCardManager _flashCardManager;
        private readonly MvxSubscriptionToken _flashCardSetSubscriptionToken;

        public FlashCardSetListViewModel(IFlashCardManager flashCardManager, IMvxMessenger messanger)
        {
            _flashCardManager = flashCardManager;
            LoadList();
            _flashCardSetSubscriptionToken = messanger.Subscribe<FlashCardSetListChangedMessage>(OnListChanged);
            StudySettings = new StudyFlashCardSetSettingsViewModel() {MaxCardsInStudySet = 0};
                //todo:start with users last settings saving states
            if (FlashCardSets.Count > 0)
            {
                SelectedSet = FlashCardSets[0];
            }
        }

        private void LoadList()
        {
            FlashCardSets = _flashCardManager.GetSetList();
        }

        private void OnListChanged(FlashCardSetListChangedMessage message)
        {
            LoadList();
        }

        private StudyFlashCardSetSettingsViewModel _studySettings;
        public StudyFlashCardSetSettingsViewModel StudySettings
        {
            get { return _studySettings; }
            set { _studySettings = value; RaisePropertyChanged(()=>StudySettings);}
        }

        private FlashCardSet _selectedSet;
        public FlashCardSet SelectedSet
        {
            get { return _selectedSet; }
            set
            {
                _selectedSet = value;
                RaisePropertyChanged(() => SelectedSet);
                SelectedSetFlashCards = GetCardsForSet();

                StudySettings.MaxCardsInStudySet = SelectedSetFlashCards.Count;

            }
        }
        
       
        private List<FlashCardSet> _flashCardSets = new List<FlashCardSet>();
        public List<FlashCardSet> FlashCardSets
        {
            get { return _flashCardSets; }
            set
            {
                _flashCardSets = value;
                RaisePropertyChanged(() => FlashCardSets);
              
            }

        }
        private List<FlashCard> _selectedSetFlashCards;
        public List<FlashCard> SelectedSetFlashCards
        {
            get { return _selectedSetFlashCards; }
            set { _selectedSetFlashCards = value;RaisePropertyChanged(()=>SelectedSetFlashCards); }
        }

        public ICommand ShowPinyinFirstCommand
        {
            get { return new MvxCommand(() => StudySettings.UpdateShowFirstSetting("Pinyin")); }
        }

        public ICommand ShowCharactersFirstCommand
        {
            get { return new MvxCommand(() => StudySettings.UpdateShowFirstSetting("Characters")); }
        }

        public ICommand ShowDefinitionFirstCommand
        {
            get { return new MvxCommand(() => StudySettings.UpdateShowFirstSetting("Definition")); }
        }


        public ICommand ShowDetailCommand
        {
            get
            {
                return
                    new MvxCommand<FlashCardSet>(
                        item =>
                            ShowViewModel<FlashCardSetDetailsViewModel>(new FlashCardSetDetailsViewModel.Nav()
                            {
                                Id = SelectedSet.ID
                            }));
            }
        }

       

        public ICommand StudySetCommand
        {
            get
            {
                return new MvxCommand<FlashCardSet>(
                    item => 
                        ShowViewModel<StudyFlashCardSetViewModel>(new Nav()
                    {
                        Id = SelectedSet.ID,
                        firstSideState = StudySettings.FirstSide.ToString() ,        //todo:change this?
                        MaxCardsInStudySet = StudySettings.MaxCardsInStudySet,
                        ShowDefinition = StudySettings.ShowDefinition,
                        ShowPinyin = StudySettings.ShowPinyin,
                        ShowSimplified = StudySettings.ShowSimplified,
                        ShowTraditional = StudySettings.ShowTraditional
                    }
                    ));
            }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _addSetCommand;

        public ICommand AddSetCommand
        {
            get
            {
                _addSetCommand = _addSetCommand ?? new MvxCommand(() =>
                {
                    DoAddCommand();
                    NewSetName = "";
                    GetFlashCardSetList();

                });
                return _addSetCommand;
            }
        }

        private void DoCreateCustomCardCommand()

        {
            ShowViewModel<CreateCustomCardViewModel>();
        }


        private MvxCommand _createFlashCardCommand;
        public ICommand CreateFlashCardCommand
        {
            get
            {
                _createFlashCardCommand = _createFlashCardCommand ?? new MvxCommand(DoCreateCustomCardCommand);
                return _createFlashCardCommand;
            }
        }

        private void DoAddCommand()
        {
            if
            (!string.IsNullOrEmpty(NewSetName))
                {
				FlashCardSet set = new FlashCardSet {SetName = NewSetName};
                    _flashCardManager.CreateSet(set);
                }
            }

       private string _newSetName;
       public string NewSetName
        {
            get { return _newSetName; }
            set
            {
                _newSetName = value;
                RaisePropertyChanged(() => NewSetName);
            }

        }
        #region privates
        private void GetFlashCardSetList()
        {
            FlashCardSets = _flashCardManager.GetSetList();
        }
        private List<FlashCard> GetCardsForSet()
        {
            return _flashCardManager.GetCardsForSet(SelectedSet.ID);
        }
        #endregion
    }
}
