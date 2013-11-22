﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Platform;
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
    public class Nav
    {
        public int Id { get; set; }

        public int MaxCardsInStudySet { get; set; }

        public string firstSideState { get; set; }

        public bool ShowPinyin { get; set; }

        public bool ShowTraditional { get; set; }

        public bool ShowSimplified { get; set; }

        public bool ShowDefinition { get; set; }

    }

  

    public class StudyFlashCardSetViewModel :  MvxViewModel
    {
        private readonly IFlashCardManager _flashCardManager;
        public StudyFlashCardSetViewModel(IFlashCardManager flashCardManager)
        {
            _flashCardManager = flashCardManager;
            

        }

       

        private StudyFlashCardSetSettingsViewModel Settings { get; set; }

        public void Init(Nav navigation)
        {
            Settings = new StudyFlashCardSetSettingsViewModel()
            {
              ShowDefinition = navigation.ShowDefinition,
              ShowSimplified = navigation.ShowSimplified,
              ShowTraditional = navigation.ShowTraditional,
              ShowPinyin = navigation.ShowPinyin,
              MaxCardsInStudySet = navigation.MaxCardsInStudySet

            };
            if (navigation.firstSideState == "English")
            {
                Settings.FirstSide = ShowSideFirstSetting.English;
                state = FlashCardStateEnum.English;
                DefaultSideIndex = 2;
            }
            else if (navigation.firstSideState == "Characters")
            {
                Settings.FirstSide = ShowSideFirstSetting.Characters;
                state = FlashCardStateEnum.Chinese;
                DefaultSideIndex = 1;
            }
            else
            {
                Settings.FirstSide = ShowSideFirstSetting.Pinyin;
                state = FlashCardStateEnum.Pinyin;
                DefaultSideIndex = 0;
            }

            Set = _flashCardManager.GetSet(navigation.Id);
            SetCards = _flashCardManager.GetCardsForSet(Set.ID);
            CurrentShowingSideIndex = DefaultSideIndex;
            CurrentCardIndex = 0;
            CurrentCard = SetCards[CurrentCardIndex];
            SetState();
            
        }


        private int _currentCardIndex;
        public int CurrentCardIndex
        {
            get { return _currentCardIndex; }
            set { _currentCardIndex = value; RaisePropertyChanged(()=>CurrentCardIndex); }
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

        private int DefaultSideIndex { get; set; }

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
                SetState();
             
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
                if (Settings.ShowPinyin)
                {
                    state = FlashCardStateEnum.Pinyin;
                    VisibleSideText = SetCards[CurrentCardIndex].AccentedPinyin;
                }
                else
                {
                    CurrentShowingSideIndex++;
                }
            }
            else if (CurrentShowingSideIndex == 1)
            {
                if (Settings.ShowDefinition)
                {
                    state = FlashCardStateEnum.English;
                    VisibleSideText = SetCards[CurrentCardIndex].Definition;
                }
                else
                {
                    CurrentShowingSideIndex++;
                }
            }
            else
            {
                if (Settings.CanShowCharacters)
                {
                    state = FlashCardStateEnum.Chinese;
                    if (Settings.ShowSimplified)
                    {
                        VisibleSideText = SetCards[CurrentCardIndex].Simplified;
                    }
                    if (Settings.ShowTraditional) //todo:better formatting of this string
                    {
                        if (Settings.ShowSimplified)
                        {
                            VisibleSideText = VisibleSideText + " " + SetCards[CurrentCardIndex].Traditional;
                        }
                        else
                        {
                            VisibleSideText = SetCards[CurrentCardIndex].Traditional;
                        }
                    }
                }
            }
        }

        public ICommand CorrectNextCardCommand 
        {
            get
            {
                return new MvxCommand(() => MoveToNextCard(true));
            }
        }

        private void MoveToNextCard(bool correct)
        {

            if (correct)
            {
                _flashCardManager.MarkCorrect(SetCards[CurrentCardIndex]);
            }
            else
            {
                _flashCardManager.MarkIncorrect(SetCards[CurrentCardIndex]);
            }

            if (CurrentCardIndex < Settings.MaxCardsInStudySet - 1)
            {
                CurrentCardIndex++;
                CurrentCard = SetCards[CurrentCardIndex];
                CurrentShowingSideIndex = DefaultSideIndex;
            }
            else
            {
                Close(this);//Todo:show set statistics
            }
        }

        public ICommand IncorrectNextCardCommand
        {
            get{return new MvxCommand(()=>MoveToNextCard(false));}
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
                SetState();
            }
        }
        #endregion



    
    }
}
