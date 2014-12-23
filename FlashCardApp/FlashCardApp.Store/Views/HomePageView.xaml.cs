using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsStore.Views;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.ViewModels;
using FlashCardApp.Core.ViewModels.Dictionary;
using FlashCardApp.Store.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Hub Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=321224

namespace FlashCardApp.Store.Views
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class HomePageView : MvxStorePage
    {




        public HomePageViewModel viewModel
        {
            get { return ((HomePageViewModel) ViewModel); }
        }

        public HomePageView()
        {
            this.InitializeComponent();
          
        }

 

        private void DictionarySetListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                viewModel.DictionaryViewModel.SelectedSet = ((FlashCardSet)e.AddedItems[0]);
                viewModel.DictionaryViewModel.AddCardToSetCommand.Execute(null);
                ((ListView) sender).SelectedIndex = -1;
            }
        }

        private void SearchBox_OnQueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
                viewModel.DictionaryViewModel.Filter = sender.QueryText;
        }
    }
}
