using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;

namespace FlashCardApp.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        
    }


}
