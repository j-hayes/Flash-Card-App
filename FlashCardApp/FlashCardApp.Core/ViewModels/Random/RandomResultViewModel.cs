using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;

namespace FlashCardApp.Core.ViewModels.Random
{
    public class RandomResultViewModel : MvxViewModel
    {
        private IDictionarySearchManager _dictionarySearchManager;
        private System.Random _random;
        public RandomResultViewModel(IDictionarySearchManager dictionarySearchManager)
        {
            _random = new System.Random();
            _dictionarySearchManager = dictionarySearchManager;
            
        }

        public SearchResult SearchResult
        {
            get
            {
                int index = _random.Next();
                var searchResult = _dictionarySearchManager.SearchByChineseId(index);
                return searchResult;
            }
        }
    }
}
