﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using FlashCardApp.Core.Messages;
using FlashCardApp.Core.Services;

namespace FlashCardApp.Core.ViewModels.Study
{
    public class FlashCardSetListViewModel : MvxViewModel
    {
        private readonly IFlashCardManager _flashCardManager;
        private readonly MvxSubscriptionToken _flashCardSetSubscriptionToken;
        private readonly IMvxMessenger _messenger;
        private readonly IStudySettingsService _settingsService;

        public FlashCardSetListViewModel(IFlashCardManager flashCardManager, IMvxMessenger messenger, IStudySettingsService settingsService)
        {

            _flashCardManager = flashCardManager;
            _messenger = messenger;
            _settingsService = settingsService;
            LoadList();
            _flashCardSetSubscriptionToken = _messenger.Subscribe<FlashCardSetListChangedMessage>(OnListChanged);
            
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

        //todo: remove this it isn't necessary with the new navigation
       /* private StudyFlashCardSetSettingsViewModel _studySettings;
        public StudyFlashCardSetSettingsViewModel StudySettings
        {
            get { return _studySettings; }
            set { _studySettings = value; RaisePropertyChanged(()=>StudySettings);}
        }*/

        private FlashCardSet _selectedSet;
        public FlashCardSet SelectedSet
        {
            get { return _selectedSet; }
            set
            {
                _selectedSet = value;
                RaisePropertyChanged(() => SelectedSet);
                SelectedSetFlashCards = GetCardsForSet();
                _messenger.Publish(new SelectedSetChangedMessage(this) {SelctedSet = SelectedSet});
                _settingsService.SetSelectedSetId(SelectedSet.ID);

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

        public ICommand GoBackCommand {get {return new MvxCommand(GoBack);} }

        public void GoBack()
        {
            Close(this);
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
