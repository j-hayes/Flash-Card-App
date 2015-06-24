using System;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;

namespace FlashCardApp.Core.ViewModels.Random
{
    public class RandomResultViewModel : MvxViewModel
    {
        private IDictionarySearchManager _dictionarySearchManager;
        private System.Random _random;
        private SearchResult _searchResult;

        public RandomResultViewModel(IDictionarySearchManager dictionarySearchManager)
        {
            _random = new System.Random();
            _dictionarySearchManager = dictionarySearchManager;
            SearchResult = searchResult;

        }

        public SearchResult SearchResult
        {
            get { return _searchResult; }
            set { _searchResult = value; RaisePropertyChanged(()=>SearchResult); }
        }

        private SearchResult searchResult
        {
            get
            {
                int index = _random.Next(1,100000);
                SearchResult s = null;
                while (s == null)
                {
                    try
                    {
                        s = _dictionarySearchManager.SearchByChineseId(index);
                    }
                    catch (Exception e)
                    {
                        
                    }
                }
                return s;
            }
            
        }
    }
}
