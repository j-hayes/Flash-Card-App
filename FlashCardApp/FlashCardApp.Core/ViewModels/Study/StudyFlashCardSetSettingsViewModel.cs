using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;

namespace FlashCardApp.Core.ViewModels.Study
{

    public enum ShowSideFirstSetting
    {
        English,
        Characters,
        Pinyin
    }

 

    public class StudyFlashCardSetSettingsViewModel : MvxViewModel
    {
        public StudyFlashCardSetSettingsViewModel()
        {

        }
        private int _maxCardsInStudySet;
        public int MaxCardsInStudySet
        {
            get { return _maxCardsInStudySet; }
            set { _maxCardsInStudySet = value; RaisePropertyChanged(() => MaxCardsInStudySet); }
        }

        private ShowSideFirstSetting _firstSide;
       


        public ShowSideFirstSetting FirstSide
        {
            get { return _firstSide; }
            set { _firstSide = value; RaisePropertyChanged(()=>FirstSide); }
        }
        private bool _showPinyin;
        public bool ShowPinyin
        {
            get { return _showPinyin; }
            set { _showPinyin = value; RaisePropertyChanged(()=>ShowPinyin); }
        }

        private bool _showTraditional;
        public bool ShowTraditional
        {
            get { return _showTraditional; }
            set { _showTraditional = value;RaisePropertyChanged(()=>ShowTraditional); }
        }

        private bool _showSimplified;
        public bool ShowSimplified
        {
            get { return _showSimplified; }
            set { _showSimplified = value; RaisePropertyChanged(()=>ShowSimplified); }
        }
        
        private bool _showDefinition;
        public bool ShowDefinition
        {
            get { return _showDefinition; }
            set { _showDefinition = value; RaisePropertyChanged( () => ShowDefinition); }
        }
    }
}
