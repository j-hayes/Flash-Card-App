using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;

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
            _showDefinition = true;
            _showPinyin = true;
            _showTraditional = true;
            _showSimplified = true;
            _canShowCharacters = true;
        }

        private bool _canShowCharacters;
        public bool CanShowCharacters
        {
            get { return _canShowCharacters; }
            private set { _canShowCharacters = value; RaisePropertyChanged(()=>CanShowCharacters);}
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

        private bool _pinyinFirst;
        public bool PinyinFirst
        {
            get { return _pinyinFirst; }
            set
            {
                _pinyinFirst = value;
				UpdateShowFirstSetting("Pinyin");
                RaisePropertyChanged(() => PinyinFirst);
            }

        }

        private bool _charactersFirst;
        public bool CharactersFirst
        {
            get { return _charactersFirst; }
            set
            {
                _charactersFirst = value;
				UpdateShowFirstSetting("Characters");//todo this should be a global enum. oh it is the windows version is the problems refactor it
                RaisePropertyChanged(() => CharactersFirst);

            }
        }

        private bool _englishFirst;
        public bool EnglishFirst
        {
            get { return _englishFirst; }
            set
            {
                _englishFirst = value;
				UpdateShowFirstSetting("English");
                RaisePropertyChanged(() => EnglishFirst);
            }
        }

        private bool _showPinyin;
        public bool ShowPinyin
        {
            get { return _showPinyin; }
            set
            {
                _showPinyin = value;
                if (value == false)
                {
                    PinyinFirst = false;
                }
                RaiseAllPropertiesChanged();
            }
        }

        private bool _showTraditional;
        public bool ShowTraditional
        {
            get { return _showTraditional; }
            set
            {
                _showTraditional = value;
                RaisePropertyChanged(() => ShowTraditional);
                if (value)
                {
                    CanShowCharacters = true;
                    

                }
                else if (ShowSimplified)
                {

                }
                else
                {
                    CanShowCharacters = false;
                    CharactersFirst = false;
                }
                RaiseAllPropertiesChanged();
            }

        }

        private bool _showSimplified;
        public bool ShowSimplified
        {
            get { return _showSimplified; }
            set
            {
                _showSimplified = value;
                RaisePropertyChanged(() => ShowSimplified);
                if (value)
                {
                    CanShowCharacters = true;
                }
                else if (ShowTraditional)
                {

                }
                else
                {
                    CanShowCharacters = false;
                    CharactersFirst = false;
                }
                RaiseAllPropertiesChanged();
            }
        }
        
        private bool _showDefinition;
        public bool ShowDefinition
        {
            get { return _showDefinition; }
            set
            {
                _showDefinition = value;
                if (value == false)
                {
                    EnglishFirst = false;
                }
                RaiseAllPropertiesChanged();
            }


        }


        public void UpdateShowFirstSetting(string sideString)
        {
            PinyinFirst = false;
            CharactersFirst = false;
            EnglishFirst = false;
            if (sideString == "Pinyin")
            {
                PinyinFirst = true;
                FirstSide = ShowSideFirstSetting.Pinyin;
            }
            else if (sideString == "Characters")
            {
                CharactersFirst = true;
                FirstSide = ShowSideFirstSetting.Characters;
            }
            else if (sideString == "Definition")
            {
                EnglishFirst = true;
                FirstSide = ShowSideFirstSetting.English;
            }
            else
            {
                throw new NotSupportedException("The side string is incorrect choices are Definition, Characters, or Pinyin");
            }
            RaiseAllPropertiesChanged();
        }
    }
}
