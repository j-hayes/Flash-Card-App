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

       

        private StudyFlashCardSetSettingsViewModel Settings { get; set; }
        public class Nav
        {
            public int Id { get; set; }

        }
        public void Init(Nav navigation)
        {
            GetSetCards(navigation.Id);
         
        }

        public bool CardSelected
        {
            get
            {
                if (SelectedCard != null)
                {
                    return true;
                }
                else
                {
                   return false;
                }

            }
            
            
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
            set { _setCards = value; RaisePropertyChanged(() => SetCards); }//todo:use FlashCardSet.Cards instead of this
        }

        public FlashCard SelectedCard
        {
            get { return _selectedCard; }
            set { _selectedCard = value; 
                RaisePropertyChanged(()=> SelectedCard);
                RaisePropertyChanged(()=> CardSelected);
            }
        }

        public ICommand DeleteCardCommand
        {
            get
            {
                return
                    new MvxCommand(() =>
                    {
                        _flashCardManager.DeleteCard(SelectedCard);
                        GetSetCards(Set.ID);
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
                if (SelectedCard != null)
                {
                    return new MvxCommand<FlashCardSet>(
                        item =>
                            ShowViewModel<FlashCardDetailsViewModel>(new FlashCardDetailsViewModel.Nav()
                            {
                                Id = SelectedCard.ID


                            }));
                }
                else
                {
                    return new MvxCommand( ()=> { ; });
                }
            }
        }


        private void GetSetCards(int id)
        {
            Set = _flashCardManager.GetSet(id);
            SetCards = _flashCardManager.GetCardsForSet(Set.ID);
        }
    }
}
