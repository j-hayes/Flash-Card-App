using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FlashCardApp.Core.ViewModels.Dictionary;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FlashCardApp.WindowsPhone.Views.Dictionary
{
    public partial class DictionaryView : MvxPhonePage
    {
        public DictionaryView()
        {
            InitializeComponent();
        }

       

        private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
             ((DictionaryViewModel) ViewModel).Filter = FilterTextBox.Text;
        }

        private void CardSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ((DictionaryViewModel)ViewModel).SelectedSearchResult = (SearchResult)e.AddedItems[0];
                ((DictionaryViewModel) ViewModel).SetListPopUpIsOpen = true;
            }
        }


        private void SetSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ((DictionaryViewModel)ViewModel).AddCardToSetCommand.Execute(e.AddedItems[0]);
                ((ListBox)sender).SelectedIndex = -1;
                ((DictionaryViewModel) ViewModel).SetListPopUpIsOpen = false;
            }
           

        }
    }
}