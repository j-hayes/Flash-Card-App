using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;

namespace FlashCardApp.Core.ViewModels.Study
{
    public class CreateCustomCardViewModel : MvxViewModel
    {
       
        private IFlashCardManager _flashCardManager;
    

        public CreateCustomCardViewModel(IFlashCardManager flashCardManager)
        {
            Card = new FlashCard();
            _flashCardManager = flashCardManager;
            FlashCardSets = _flashCardManager.GetSetList();
            if (FlashCardSets.Count > 0)
            {
                SelectedFlashCardSet = FlashCardSets[0];
                SelectedSetIndex = 0;//Todo: make this actually show the 0th item on loading the page in the combo box

            }
        }


        private FlashCard _card;
        public FlashCard Card
        {
            get { return _card; }
            set { _card = value; RaisePropertyChanged(()=> Card);  }
        }

        private FlashCardSet _selectedFlashCardSet;
        public FlashCardSet SelectedFlashCardSet
        {
            get { return _selectedFlashCardSet; }
            set { _selectedFlashCardSet = value; RaisePropertyChanged(()=>SelectedFlashCardSet); }
        }

        private List<FlashCardSet> _flashCardSets;
        private int _selectedSetIndex;

        public List<FlashCardSet> FlashCardSets
        {
            get { return _flashCardSets; }
            set { _flashCardSets = value; RaisePropertyChanged(()=>FlashCardSets); }
        }

        public int SelectedSetIndex
        {
            get { return _selectedSetIndex; }
            set { _selectedSetIndex = value; RaisePropertyChanged(() => SelectedSetIndex); }
        }


        public ICommand AddCardToSetCommand
        {
            get
            {
                return new MvxCommand(
                    DoAddCardToSetCommand);
            }
        }

        private void DoAddCardToSetCommand()
        {
            _flashCardManager.CreateCard(Card);
            if (FlashCardSets.Count < 1 || SelectedFlashCardSet == null)
            {
                _flashCardManager.CreateSet(new FlashCardSet("Uncategorized"));
                FlashCardSets = _flashCardManager.GetSetList();
                _flashCardManager.AddCardtoSet(Card.ID, FlashCardSets[0].ID);
            }
            else
            {
                _flashCardManager.AddCardtoSet(Card.ID, SelectedFlashCardSet.ID);
                
            }
            Close(this);
        }
    }
}
