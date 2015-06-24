using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FlashCardApp.Core.ViewModels.Dictionary;
using FlashCardApp.Core.ViewModels.Study;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FlashCardApp.WindowsPhone.Views.Dictionary
{
    public partial class AddSearchResultToSetView : MvxPhonePage
    {
        public AddSearchResultToSetView()
        {
            InitializeComponent();
        }

        public AddSearchResultToSetViewModel viewModel
        {
            get { return (AddSearchResultToSetViewModel)base.ViewModel; }
        }

    }
}