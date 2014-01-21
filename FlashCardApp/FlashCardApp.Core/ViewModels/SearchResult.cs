using System;
using System.Collections.Generic;
using System.Text;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Helpers;

namespace FlashCardApp.Core.ViewModels.Dictionary
{
    public class SearchResult
    {
        public Chinese Chinese { get; set; }
        public string Traditional { get; set; }
        public string Simplified { get; set; }
        public string Pinyin { get; set; }
        public int ChineseId;


        public string AccentedPinyin
        {
            get
            {
                return PinyinFormatHelper.ConvertNumericalPinYinToAccented(Pinyin);
            }
        }



        public string DefintionsString
        {
            get { return GetDefinitionString(); }
        }

        public List<string> Definitions { get; set; }

        private string GetDefinitionString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string definition in Definitions)
            {
                sb.Append(string.Format("{0}; ", definition));
            }
            string returnString = sb.ToString();

            if (returnString.Length > 0)
            {
                returnString = returnString.Remove(returnString.Length - 2);
            }
            return returnString;
        }


        public SearchResult()
        {
            Definitions = new List<string>();
        }

        public override bool Equals(object obj)
        {
            SearchResult test = new SearchResult();
            try
            {
                test = (SearchResult) obj;
            }
            catch (Exception)
            {

                return false;
            }
            return this.ChineseId == test.ChineseId;
        }
    }
}

