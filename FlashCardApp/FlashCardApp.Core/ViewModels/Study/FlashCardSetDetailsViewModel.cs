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
            SetCards = _flashCardManager.GetCardsForSet(Set.ID);
        }

        private FlashCardSet _set;
        public FlashCardSet Set
        {
            get { return _set; }
            set { _set = value; RaisePropertyChanged(() => Set); }
        }

        private List<FlashCard> _setCards;
        public List<FlashCard> SetCards
        {
            get { return _setCards; }
            set { _setCards = value; RaisePropertyChanged(() => SetCards); }
        }

        public ICommand DeleteCardCommand()
        {
            throw new NotImplementedException();
            //todo: create remove cards from the set; ask if delete from alls
        }

        public ICommand DeletSetCommandCommand
        {
            get
            {
                return new MvxCommand(()=>
                {
                    _flashCardManager.DeleteSet(Set);
                    Close(this);
                });
            }
        }
    }
}
