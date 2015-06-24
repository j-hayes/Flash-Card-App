using System.Collections.Generic;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Core.Managers
{
    public interface IDictionarySearchManager
    {
        List<SearchResult> SearchByEnglish(string searchTerm);
        List<SearchResult> SearchByChinese(string searchTerm);
		SearchResult SearchByChineseId (int Id);
        List<SearchResult> SearchByPinYin(string searchTerm);
    }
}