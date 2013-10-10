using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;

namespace FlashCardApp.Core.ViewModels.Study
{
    internal enum FlashCardStateEnum
    {
        Chinese = 2,
        English = 1,
        Pinyin = 0
    }

    public class StudyFlashCardSetViewModel :  MvxViewModel
    {
        private IFlashCardManager _flashCardManager;


        public StudyFlashCardSetViewModel(IFlashCardManager flashCardManager)
        {
            _flashCardManager = flashCardManager;
            

        }

        public class Nav
        {
            public int Id { get; set; }
        }

        public void Init(FlashCardSetDetailsViewModel.Nav navigation)
        {
            Set = _flashCardManager.GetSet(navigation.Id);
            SetCards = _flashCardManager.GetCardsForSet(Set.ID);
            CurrentShowingSideIndex = 2;
            state = FlashCardStateEnum.Chinese;
            CurrentCardIndex = 0;
            CurrentCard = SetCards[CurrentCardIndex];
           
        }

        public int CurrentCardIndex
        {
            get { return _currentCardIndex; }
            set { _currentCardIndex = value; }
        } //todo reset card to chinese / the actual one they want to see first

        private int _currentShowingSideIndex;
        private int CurrentShowingSideIndex
        {
            get { return _currentShowingSideIndex; }
            set { _currentShowingSideIndex = value; SetState(); }
        }

        private FlashCardStateEnum state
        {
            get; 
            set;
        }

        #region constants

        private const int MaxShowingIndex = 2; //this the maximum number of sides a card can have -1 to make it the max index for the variable holding sides of a card
        #endregion
        #region properties
        private List<FlashCard> _setCards;
        public List<FlashCard> SetCards
        {
            get { return _setCards; }
            set { _setCards = value; RaisePropertyChanged(() => SetCards); }
        }

        private FlashCardSet _set;
        public FlashCardSet Set
        {
            get { return _set; }
            set { _set = value; RaisePropertyChanged(() => Set); }
        }

        private FlashCard _currentCard;
        public FlashCard CurrentCard
        {
            get { return _currentCard; }
            set { _currentCard = value; RaisePropertyChanged(() => CurrentCard);
                VisibleSideText = CurrentCard.Simplified;
            }
        }


        private int _currentCardIndex;

        private string _visibleSideText;
        public string VisibleSideText
        {
            get { return _visibleSideText; }
            set { _visibleSideText = value; RaisePropertyChanged(() => VisibleSideText); }
        }

        #endregion
        #region commands

        public ICommand FlipCardRightCommand
        {
            get { return new MvxCommand(FlipCardRight); }
        }

        private void FlipCardRight()
        {
            if (CurrentShowingSideIndex == MaxShowingIndex)
            {
                CurrentShowingSideIndex = 0;
               
            }
            else
            {
                CurrentShowingSideIndex++;
             
            }
        }

        public ICommand FlipCardLeftCommand
        {
            get { return new MvxCommand(FlipCardLeft); }
        }

        private void FlipCardLeft()
        {
            if (CurrentShowingSideIndex == 0)
            {
                CurrentShowingSideIndex = MaxShowingIndex;
                SetState();
            }
            else
            {
                CurrentShowingSideIndex--;
                SetState();
            }
        }

        private void SetState()
        {
            if (CurrentShowingSideIndex == 0)
            {
                state = FlashCardStateEnum.Pinyin;
                VisibleSideText = SetCards[CurrentCardIndex].Pinyin;
            }
            else if (CurrentShowingSideIndex == 1)
            {
                state = FlashCardStateEnum.English;
                VisibleSideText = SetCards[CurrentCardIndex].Definition;
            }
            else
            {
                state = FlashCardStateEnum.Chinese;
                VisibleSideText = SetCards[CurrentCardIndex].Simplified;
            }
        }

        public ICommand NextCardCommand 
        {
            get
            {
                return new MvxCommand(MoveToNextCard);
            }
        }

        private void MoveToNextCard()
        {
            if (CurrentCardIndex < SetCards.Count - 1)
            {
                CurrentCardIndex++;
                CurrentCard = SetCards[CurrentCardIndex];
            }
            else
            {
                //todo: do done with set behavior
            }
        }

        public ICommand PreviousCardCardCommand
        {
            get
            {
                return new MvxCommand(MoveToPreviousCard);
            }
        }

        private void MoveToPreviousCard()
        {
          if(CurrentCardIndex > 0)
            {
                CurrentCardIndex--;
                CurrentCard = SetCards[CurrentCardIndex];
            }
        }
        #endregion



    
    }
}
