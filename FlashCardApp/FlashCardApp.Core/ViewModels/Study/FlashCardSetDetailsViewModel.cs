using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;

namespace FlashCardApp.Core.ViewModels.Study
{
    public class FlashCardSetDetailsViewModel: MvxViewModel
    {
        private readonly IFlashCardManager _flashCardManager;

        public FlashCardSetDetailsViewModel(IFlashCardManager flashCardManager)
        {
            _flashCardManager = flashCardManager;
        }

        public class Nav
        {
            public int Id { get; set; }
        }

        public void Init(Nav navigation)
        {
            Set = _flashCardManager.GetSet(navigation.Id);
            GetSetCards();
        }

       

        private FlashCardSet _set;
        public FlashCardSet Set
        {
            get { return _set; }
            set { _set = value; RaisePropertyChanged(() => Set); }
        }

        private List<FlashCard> _setCards;
        private FlashCard _selectedCard;

        public List<FlashCard> SetCards
        {
            get { return _setCards; }
            set { _setCards = value; RaisePropertyChanged(() => SetCards); }
        }

        public FlashCard SelectedCard
        {
            get { return _selectedCard; }
            set { _selectedCard = value; RaisePropertyChanged(()=> SelectedCard);}
        }

        public ICommand DeleteCardCommand
        {
            get
            {
                return
                    new MvxCommand(() =>
                    {
                        _flashCardManager.DeleteCard(SelectedCard);
                        GetSetCards();
                    });

                //todo: messanger that this set has been updated
            }
        }

        public ICommand DeleteSetCommand
        {
            get
            {
                return new MvxCommand(()=>
                {
                    _flashCardManager.DeleteSet(Set);
                    //todo: add a messanger to update that this flash set has been deleted
                    Close(this);
                });
            }
        }

        public ICommand ShowCardDetailCommand
        {
            get
            {
               return new MvxCommand<FlashCardSet>(
                          item =>
                              ShowViewModel<FlashCardDetailsViewModel>(new FlashCardDetailsViewModel.Nav()
                              {
                                  Id = SelectedCard.ID
                              }));
            }    
        }

        private void GetSetCards()
        {
            SetCards = _flashCardManager.GetCardsForSet(Set.ID);
        }
    }
}
