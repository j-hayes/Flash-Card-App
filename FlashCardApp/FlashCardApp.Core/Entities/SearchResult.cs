using System;
using System.Collections.Generic;
using System.Text;
using FlashCardApp.Core.Helpers;

namespace FlashCardApp.Core.Entities
{
    public class SearchResult
    {
        public Chinese Chinese { get; set; }
        public string Traditional { get; set; }
        public string Simplified { get; set; }
		private string _pinyin;
        public string Pinyin {
			get {
				return _pinyin;
			}
			set {
				_pinyin = value;
				AccentedPinyin = value;
			}
		}
        public int ChineseId;


		private string _accentedPinyin;
        public string AccentedPinyin
        {
			set{ 
				_accentedPinyin = value;
			}
            get
            {
				return PinyinFormatHelper.ConvertNumericalPinYinToAccented(_accentedPinyin);
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

		public SearchResult(List<English> englishes, Chinese chinese)
		{
			Definitions = new List<string> ();
			foreach (English e in englishes) 
			{
				Definitions.Add (e.Definition);
			}

			Traditional = chinese.Traditional;
			Simplified = chinese.Simplified;
			Pinyin = chinese.Pinyin;
			ChineseId = chinese.ID;
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

