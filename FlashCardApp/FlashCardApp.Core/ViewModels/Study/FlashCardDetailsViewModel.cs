using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;

namespace FlashCardApp.Core.ViewModels.Study
{
    public class FlashCardDetailsViewModel : MvxViewModel
    {
        private FlashCard _card;

        private IFlashCardManager _flashCardManager;
        private bool _editModeOff;

        public FlashCardDetailsViewModel(IFlashCardManager flashCardManager)
        {
            _flashCardManager = flashCardManager;
            EditModeOff = true;
        }

        public class Nav
        {
            public int Id { get; set; }
        }

        public void Init(Nav navigation)
        {
            Card = _flashCardManager.GetCard(navigation.Id);
        }

        public FlashCard Card
        {
            get { return _card; }
            set { _card = value; RaisePropertyChanged(()=> Card);  }
        }

        public bool EditModeOff
        {
            get { return _editModeOff; }
            set { _editModeOff = value; RaisePropertyChanged( ()=> EditModeOff); }
        }

        public ICommand UpdateCardCommand
        {
            get
            {
                return new MvxCommand(
                    () =>
                    {
                        _flashCardManager.EditCard(Card);
                        EditModeOff = false;
                        Close(this);
                    });
            }
        }
    }
}
