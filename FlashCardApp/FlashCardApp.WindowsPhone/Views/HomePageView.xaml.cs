﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FlashCardApp.Core.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FlashCardApp.WindowsPhone.Views
{
    public partial class HomePageView : MvxPhonePage
    {
        public HomePageView()
        {
            InitializeComponent();
        }

        public HomePageViewModel viewModel
        {
            get { return ((HomePageViewModel) base.ViewModel); }
        }

        private void DictionaryFilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DictionaryResultsView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DictionarySetListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}