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
        }

        private void LoadList()
        {
            FlashCardSets = _flashCardManager.GetSetList();
        }

        private void OnListChanged(FlashCardSetListChangedMessage message)
        {
            LoadList();
        }

        private FlashCardSet _selectedSet;
        public FlashCardSet SelectedSet
        {
            get { return _selectedSet; }
            set { _selectedSet = value;
                RaisePropertyChanged(() => SelectedSet);
                SelectedSetFlashCards = GetCardsForSet();
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
                                Id = item.ID
                            }));
            }
        }

        public ICommand StudySetCommand
        {
            get
            {
                return new MvxCommand<FlashCardSet>(
                    item => 
                        ShowViewModel<StudyFlashCardSetViewModel>(new StudyFlashCardSetViewModel.Nav()
                    {
                        Id = item.ID
                    }));
            }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                _addCommand = _addCommand ?? new MvxCommand(() =>
                {
                    DoAddCommand();
                    NewSetName = "";
                    GetFlashCardSetList();

                });
                return _addCommand;
            }
        }



        private void DoAddCommand()
        {
            FlashCardSet set = new FlashCardSet {Name = NewSetName};
            _flashCardManager.CreateSet(set);
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
