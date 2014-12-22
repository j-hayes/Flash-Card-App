using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using FlashCardApp.Core.ViewModels;
using System.Linq;
using FlashCardApp.Core.ViewModels.Study;
using System.Windows;

namespace FlashCardApp.Core.ViewModels.Dictionary
{
	public enum DictionarySearchInputType : int
    {
       
        Chinese = 0,
		English = 1,
        Pinyin = 2 

		
    }

    public class DictionaryViewModel: MvxViewModel
    {


        private readonly IDictionarySearchManager _dictionarySearchManager;
        private readonly IFlashCardManager _flashCardManager;
        public DictionaryViewModel(IDictionarySearchManager dictionarySearchManager, IFlashCardManager flashCardManager)
        {
            _dictionarySearchManager = dictionarySearchManager;
            _flashCardManager = flashCardManager;

			SearchInputType = DictionarySearchInputType.English; 
            AvailibleDictionarySearchInputTypes = new DictionarySearchInputType[]
            {
                DictionarySearchInputType.English,
                DictionarySearchInputType.Chinese,
                DictionarySearchInputType.Pinyin
            };

            SetListPopUpIsOpen = false;
            GetFlashCardSets();
        }

        public bool SetListPopUpIsOpen
        {
            get { return _setListPopUpIsOpen; }
            set { _setListPopUpIsOpen = value;RaisePropertyChanged(()=>SetListPopUpIsOpen); }
        }

        private List<SearchResult> _searchResults = new List<SearchResult>();
        public List<SearchResult> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                RaisePropertyChanged(() => SearchResults);
            }

        }

        private string _searchTerm = "";
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                RaisePropertyChanged(() => SearchTerm);
            }
        }

        private string _filter = "";
        public string Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                RaisePropertyChanged(() => Filter);
                ThreadPool.QueueUserWorkItem(DoApplyFilter, Filter);
                //todo: use the expanded search functionarlity and add them to the searchresult list
            }
        }

        //todo: this isn't being used properly in the view because its not on a button click..
        private Cirrious.MvvmCross.ViewModels.MvxCommand _applySearchCommand;
        /* public System.Windows.Input.ICommand ApplyFilterCommand
        {
            get
            {
                _applySearchCommand = _applySearchCommand ?? new MvxCommand(() => DoApplyFilter());
                return _applySearchCommand;
            }
        }*/

        public DictionarySearchInputType[] AvailibleDictionarySearchInputTypes{get; private set;}

        private DictionarySearchInputType _searchInputType;
        public DictionarySearchInputType SearchInputType
        {
            get { return _searchInputType; }
            set
            {
                _searchInputType = value;
                RaisePropertyChanged(() => SearchInputType);
            }
        }

        private void DoApplyFilter(object obj)
        {
            string filterString = obj.ToString();
            List<SearchResult> results;
            if (SearchInputType == DictionarySearchInputType.English)
            {
                 results = _dictionarySearchManager.SearchByEnglish(Filter);
               
            }
            else if (SearchInputType == DictionarySearchInputType.Chinese)
            {
                results = _dictionarySearchManager.SearchByChinese(Filter);
              
            }
            else
            {
                results = _dictionarySearchManager.SearchByPinYin(Filter);
               
            }
            if (results != null & filterString == Filter)
            {
                SearchResults = results;
            }
           
        }

        private List<FlashCardSet> _flashCardList;
        public List<FlashCardSet> FlashCardSetList 
        {
            get { return _flashCardList; }
            set
            {
                _flashCardList = value;
                RaisePropertyChanged(() => FlashCardSetList);
            }
        }

        private SearchResult _selectedSearchResult;
        public SearchResult SelectedSearchResult
        {
            get { return _selectedSearchResult; }
            set
            {
                _selectedSearchResult = value;
                
                
                
                RaisePropertyChanged(() => SelectedSearchResult);
                SelectedCard = new FlashCard()
                {
                    Definition = SelectedSearchResult.DefintionsString,
                    Pinyin = SelectedSearchResult.Pinyin,
                    Traditional = SelectedSearchResult.Traditional,
                    Simplified = SelectedSearchResult.Simplified
                };
            }
        }

        private FlashCard _selectedCard;
        public FlashCard SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                _selectedCard = value;
                RaisePropertyChanged(() => SelectedCard);
            }
        }

        private FlashCardSet _selectedSet;
        private bool _setListPopUpIsOpen;

        public FlashCardSet SelectedSet
        {
            get { return _selectedSet; }
            set
            {
                _selectedSet = value;
                RaisePropertyChanged(() => SelectedSet);
            }
        }

        public ICommand GetFlashCardSetList
        {
            get
            {
                return new MvxCommand(GetFlashCardSets);
            }
        }

        private void GetFlashCardSets()
        {
            FlashCardSetList = _flashCardManager.GetSetList();
        }


        public ICommand AddCardToSetCommand
 
        {
            get
            {
                return new MvxCommand(DoAddToSetCommand);
            }
        }

		private void DoAddToSetCommand()
        {
            
            int flashCardId = _flashCardManager.CreateCard(SelectedCard);
            _flashCardManager.AddCardtoSet(flashCardId, SelectedSet.ID);
            SetListPopUpIsOpen = false;
        }

		public void ShowSearchResultViewModel()
		{
			ShowViewModel<SearchResultViewModel>(new FlashCardApp.Core.ViewModels.Dictionary.SearchResultViewModel.DictionarySearchResultNav()
				{
					Id = SelectedSearchResult.ChineseId
				});
		}
    }
}