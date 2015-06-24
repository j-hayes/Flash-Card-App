namespace FlashCardApp.Core.ViewModels.Dictionary
{
    public class DictionarySearchResult
    {
        public string Traditional { get; set; }
        public string Simplified { get; set; }
        public string Pinyin { get; set; }
        public int ChineseID { get; set; }
        public string Definition { get; set; }


        public DictionarySearchResult(int chineseID, string traditional, string simplified, string pinyin, string defintion)
        {
            Traditional = traditional;
            Simplified = simplified;
            Pinyin = pinyin;
            ChineseID = chineseID;
            Definition = defintion;
        }
    }
}
