using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using FlashCardApp.Core.ViewModels.Study;

namespace FlashCardApp.Core.ViewModels.Dictionary
{
    public class AddSearchResultToSetViewModel : MvxViewModel
    {
        
        private readonly IFlashCardManager _flashCardManager;

        public AddSearchResultToSetViewModel(IFlashCardManager flashCardManager)
        {
            _flashCardManager = flashCardManager;
        }

        public void Init(FlashCard card)
        {
            Card = card;
            var setList = _flashCardManager.GetSetList();
            SetList = setList.Select(x => new WithCommand<FlashCardSet>(x, new MvxCommand(() => AddToSet(Card, x)))).ToList();
        }

        private void AddToSet(FlashCard card, FlashCardSet flashCardSet)
        {
           var id = _flashCardManager.CreateCard(Card);
           _flashCardManager.AddCardtoSet(id,flashCardSet.ID);
            Close(this);
        }

        private FlashCard _card;
        public FlashCard Card
        {
            get { return _card; }
            set
            {
                _card = value;
                RaisePropertyChanged(() => Card);
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

        public ICommand CreateCustomCardCommand
        {
            get { return new MvxCommand(()=>ShowViewModel<CreateCustomCardViewModel>(Card));}
        }
    }
}