using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using Cirrious.MvvmCross.Plugins.Sqlite;
using FlashCardApp.Core.Managers.FlashCardApp.Core.Services;
using FlashCardApp.Core.ViewModels.Dictionary;
using FlashCardApp.Core.ViewModels.Study;

namespace FlashCardApp.Core.ViewModels
{
    class HomePageViewModel : MvxViewModel
    {
        private string _searchTerm = "";
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value; RaisePropertyChanged(() => SearchTerm);
            }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _dictionaryCommand;
        public ICommand DictionaryCommand
        {
            get
            {
                _dictionaryCommand = _dictionaryCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(NavigateToDictionary);
                return _dictionaryCommand;
            }
        }
        private void NavigateToDictionary()
        {
            ShowViewModel<DictionaryViewModel>();
        }
        
        private MvxCommand _flashCardCommand;
        public ICommand FlashCardCommand
        {
            get
            {
                _flashCardCommand = _flashCardCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(NavigateToFlashCardSetList);
                return _flashCardCommand;
            }
        }

        
        private void NavigateToFlashCardSetList()
        {
            ShowViewModel<FlashCardSetListViewModel>();
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _testNavigationCommnad;
        public System.Windows.Input.ICommand TestNavigationCommnad
        {
            get
            {
                _testNavigationCommnad = _testNavigationCommnad ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(NavigateToTest);
                return _testNavigationCommnad;
            }
        }

        private void NavigateToTest()
        {
            ShowViewModel<TestNavigationViewModel>();
        }
    }
}
