using System;
using System.Collections.Generic;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Cirrious.MvvmCross.WindowsCommon.Views;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.ViewModels.Dictionary;

using FlashCardApp.Store.Common;

namespace FlashCardApp.Store.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DictionaryView : MvxWindowsPage
    {
        public DictionaryView()
        {
            this.InitializeComponent();
        }
        
        private void CardSelected(object sender, SelectionChangedEventArgs e)
        {
            
            if (e.AddedItems.Count == 1)
            {
                ((DictionaryViewModel) ViewModel).SelectedSearchResult = (SearchResult)e.AddedItems[0];
                bottomAppBar.IsOpen = true;
            }
        }

        private void AddToSetButtonClick(object sender, RoutedEventArgs e)
        {
            
            //todo:change this to a pop up instead of a top app bar
           ((DictionaryViewModel)ViewModel).GetFlashCardSetList.Execute(sender);
            topAppBar.IsOpen = true;
        }


        private void AddCardSetSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ((DictionaryViewModel) ViewModel).AddCardToSetCommand.Execute(e.AddedItems[0]);
                ((GridView) sender).SelectedIndex = -1;
            }
            bottomAppBar.IsOpen = false;
            topAppBar.IsOpen = false;

            //Todo: display a success message
        }


        private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ((DictionaryViewModel) ViewModel).Filter = FilterTextBox.Text;
        }
    }
}
