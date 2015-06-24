using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FlashCardApp.Core.ViewModels.Study;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FlashCardApp.WindowsPhone.Views.Study
{
    public partial class FlashCardSetListView : MvxPhonePage
    {
        public FlashCardSetListView()
        {
            InitializeComponent();
        }

        public FlashCardSetListViewModel viewModel
        {
            get { return (FlashCardSetListViewModel) base.ViewModel; }
        }

    }
}