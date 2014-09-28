using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers;
using FlashCardApp.Core.ViewModels;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace FlashCardApp.Core.ViewModels.Dictionary
{
	public class SearchResultViewModel : MvxViewModel
	{
		private IFlashCardManager _flashCardManager;
		private IMvxMessenger _messanger;
		private IDictionarySearchManager _dictionarySearchResultManager;

		private SearchResult _theSearchResult;
		public SearchResult TheSearchResult {
			get {
				return _theSearchResult;
			}
			set {
				_theSearchResult = value;
				RaisePropertyChanged (() => TheSearchResult);
			}
		}

		private FlashCardSet _selectedFlashCardSet;
		public FlashCardSet SelectedFlashCardSet {
			get {
				return _selectedFlashCardSet;
			}
			set {
				_selectedFlashCardSet = value;
				RaisePropertyChanged (() => SelectedFlashCardSet);
			}
		}

		public List<FlashCardSet> _flashCardSets;
		public List<FlashCardSet> FlashCardSets {
			get {
				return _flashCardSets;
			}
			set {
				_flashCardSets = value;
				RaisePropertyChanged (() => FlashCardSets);
			
			}
		}

		private string _errorMessage;
		public string ErrorMessage {
			get {
				return _errorMessage;
			}
			set {
				_errorMessage = value;
				RaisePropertyChanged (() => ErrorMessage);
			}
		}


		public SearchResultViewModel(IFlashCardManager flashCardManager, IMvxMessenger messanger, IDictionarySearchManager dictionarySearchManager)
		{
			_flashCardManager = flashCardManager;
			_messanger = messanger;
			_dictionarySearchResultManager = dictionarySearchManager; 
			FlashCardSets = _flashCardManager.GetSetList ();
			if (FlashCardSets != null && FlashCardSets.Count > 0) {
				SelectedFlashCardSet = FlashCardSets [0];
			} 
			else
			{
				ErrorMessage = "You Have No Flash Card Sets. Please create one to add cards.";
			}
		}

		public class DictionarySearchResultNav
		{
			public int Id { get; set; }
		}

		public void Init( DictionarySearchResultNav nav)
		{
			TheSearchResult = _dictionarySearchResultManager.SearchByChineseId (nav.Id);
		}

		public ICommand AddCardToSetCommand {
			get {
				return new MvxCommand (DoAddCardToSet);

			}
		}

		private void DoAddCardToSet()
		{
			int cardId =_flashCardManager.CreateCard (new FlashCard () {	
				Simplified = TheSearchResult.Simplified,
				Traditional = TheSearchResult.Traditional,
				Pinyin = TheSearchResult.AccentedPinyin,
				Definition = TheSearchResult.DefintionsString

			}
			);

			_flashCardManager.AddCardtoSet (cardId, SelectedFlashCardSet.ID);
			Close (this);
	
		}
	}
}