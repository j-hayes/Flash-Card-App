using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;

namespace FlashCardApp.Core.ViewModels
{
    class TestNavigationViewModel : MvxViewModel
    {
        private string s;
        public TestNavigationViewModel() 
        {
            s = "2";
        }
    }
}
