using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using FlashCardApp.Core.Services;
using FlashCardApp.Core.ViewModels.Study;

namespace FlashCardApp.Core.ViewModels.Dictionary
{
    public enum DictionarySearchInputType
    {
        Chinese = 0,
        English = 1,
        Pinyin = 2
    }

    public class DictionaryViewModel : MvxViewModel
    {
        private readonly IDictionarySearchManager _dictionarySearchManager;
        private readonly IFlashCardManager _flashCardManager;
        private readonly IStudySettingsService _studySettingsService;
        private MvxCommand _applySearchCommand;
        private string _filter = "";
        private List<FlashCardSet> _flashCardList;
        private DictionarySearchInputType _searchInputType;
        private List<WithCommand<SearchResult>> _searchResults = new List<WithCommand<SearchResult>>();
        private string _searchTerm = "";
        private FlashCard _selectedCard;
        private SearchResult _selectedSearchResult;
        private FlashCardSet _selectedSet;
        private bool _setListPopUpIsOpen;
        private ICommand _setEnglishAsTypeCommand;

        public DictionaryViewModel(IDictionarySearchManager dictionarySearchManager, IFlashCardManager flashCardManager, IStudySettingsService studySettingsService)
        {
            _dictionarySearchManager = dictionarySearchManager;
            _flashCardManager = flashCardManager;
            _studySettingsService = studySettingsService;

            _searchInputType = DictionarySearchInputType.English;
            SearchTypeIsEnglish = true;
            AvailibleDictionarySearchInputTypes = new[]
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
            get { return SelectedSearchResult != null; }
            set
            {
                _setListPopUpIsOpen = value;
                RaisePropertyChanged(() => SetListPopUpIsOpen);
            }
        }

        public List<WithCommand<SearchResult>> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                RaisePropertyChanged(() => SearchResults);
             
            }
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                  RaisePropertyChanged(() => Filter);
                DoApplyFilter(_filter);
           
              
                //todo: use the expanded search functionarlity and add them to the searchresult list
            }
        }

        //todo: this isn't being used properly in the view because its not on a button click..
        /* public System.Windows.Input.ICommand ApplyFilterCommand
        {
            get
            {
                _applySearchCommand = _applySearchCommand ?? new MvxCommand(() => DoApplyFilter());
                return _applySearchCommand;
            }
        }*/

        public DictionarySearchInputType[] AvailibleDictionarySearchInputTypes { get; private set; }

        public DictionarySearchInputType SearchInputType
        {
            get { return _searchInputType; }
            set
            {
                _searchInputType = value;
                RaisePropertyChanged(() => SearchInputType);
                DoApplyFilter(Filter);
            }
        }

        public List<FlashCardSet> FlashCardSetList
        {
            get { return _flashCardList; }
            set
            {
                _flashCardList = value;
                RaisePropertyChanged(() => FlashCardSetList);
            }
        }

        public SearchResult SelectedSearchResult
        {
            get { return _selectedSearchResult; }
            set
            {
                _selectedSearchResult = value;
                RaisePropertyChanged(() => SelectedSearchResult);
                if (value != null)
                {
                    SelectedCard = new FlashCard
                    {
                        Definition = SelectedSearchResult.DefintionsString,
                        Pinyin = SelectedSearchResult.Pinyin,
                        Traditional = SelectedSearchResult.Traditional,
                        Simplified = SelectedSearchResult.Simplified
                    };
                }
                RaisePropertyChanged(() => SetListPopUpIsOpen);
            }
        }

        public FlashCard SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                _selectedCard = value;
                RaisePropertyChanged(() => SelectedCard);
            }
        }

        public FlashCardSet SelectedSet
        {
            get { return _selectedSet; }
            set
            {
                _selectedSet = value;
                RaisePropertyChanged(() => SelectedSet);
            }
        }

        private bool _searchTypeIsEnglish;
        public bool SearchTypeIsEnglish
        {
            get { return _searchTypeIsEnglish; }
            set
            {
                _searchTypeIsEnglish = value;
                RaisePropertyChanged(() => SearchTypeIsEnglish);
            }
        }

        private bool _searchTypeIsPinyin;
        public bool SearchTypeIsPinyin
        {
            get { return _searchTypeIsPinyin; }
            set
            {
                _searchTypeIsPinyin = value;
                RaisePropertyChanged(() => SearchTypeIsPinyin);
            }
        }

        private bool _searchTypeIsChinese;
        public bool SearchTypeIsChinese
        {
            get { return _searchTypeIsChinese; }
            set
            {
                _searchTypeIsChinese = value;
                RaisePropertyChanged(() => SearchTypeIsChinese);
            }
        }

        public ICommand SetEnglishAsTypeCommand
        {
            get { return new MvxCommand(() =>
            {
                SearchInputType = DictionarySearchInputType.English;
                UpdateSearchType(SearchInputType);

            }); }
        } 
        public ICommand SetPinyinAsTypeCommand
        {
            get { return new MvxCommand(() =>
            {
                SearchInputType = DictionarySearchInputType.Pinyin;
                UpdateSearchType(SearchInputType);
            }); }
        } 
        public ICommand SetChineseAsTypeCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    SearchInputType = DictionarySearchInputType.Chinese;
                    UpdateSearchType(SearchInputType);
                });
                
            }
        }

        private void UpdateSearchType(DictionarySearchInputType type)
        {
            _searchTypeIsEnglish = false;
            _searchTypeIsChinese = false;
            _searchTypeIsPinyin = false;

            switch (type)
            {
                 case DictionarySearchInputType.Chinese:
                    _searchTypeIsChinese = true;
                    break;
                case DictionarySearchInputType.English:
                    _searchTypeIsEnglish = true;
                    break;
                case DictionarySearchInputType.Pinyin:
                    _searchTypeIsPinyin = true;
                    break;
            }
            RaiseAllPropertiesChanged();
        }

        public ICommand GetFlashCardSetList
        {
            get { return new MvxCommand(GetFlashCardSets); }
        }


        public ICommand AddCardToSetCommand

        {
            get
            {
                
                return new MvxCommand(() => 
                    DoAddToSetCommand(SelectedSearchResult));
            }
        }

        private async Task DoApplyFilter(string filterString)
        {
            if (SearchTypeIsChinese && filterString.Contains("'"))
            {
                return;
            }
            await Task.Run(() =>
            {
                try
                {
                    List<SearchResult> results;
                    switch (SearchInputType)
                    {
                        case DictionarySearchInputType.English:
                            results = _dictionarySearchManager.SearchByEnglish(Filter);
                            break;
                        case DictionarySearchInputType.Chinese:
                            results = _dictionarySearchManager.SearchByChinese(Filter);
                            break;
                        default:
                            results = _dictionarySearchManager.SearchByPinYin(Filter);
                            break;
                    }
                    if (!(results != null & filterString == Filter)) return;
                    SearchResults = new List<WithCommand<SearchResult>>();


                    foreach (var searchResult in results)
                    {
                        if (searchResult == null)
                        {
                            continue;
                        }
                        SearchResult result = searchResult;
                        SearchResults.Add(new WithCommand<SearchResult>(searchResult,
                            new MvxCommand(() => DoAddToSetCommand(result))));
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            });
            
        }

        private void GetFlashCardSets()
        {
            FlashCardSetList = _flashCardManager.GetSetList();
        }

        private void DoAddToSetCommand(SearchResult result)
        {
            if (result == null)
            {
                return;
            }
            var selectedSetId = _studySettingsService.GetSelectedSetId();
            var newCard = new FlashCard()
            {
                Definition = result.DefintionsString,
                Pinyin = result.Pinyin,
                Traditional = result.Traditional,
                Simplified = result.Simplified

            };
            ShowViewModel<AddSearchResultToSetViewModel>(newCard);
            SetListPopUpIsOpen = false;
        }


        public void ShowSearchResultViewModel()
        {
            ShowViewModel<SearchResultViewModel>(new SearchResultViewModel.DictionarySearchResultNav
            {
                Id = SelectedSearchResult.ChineseId
            });
        }
    }
}