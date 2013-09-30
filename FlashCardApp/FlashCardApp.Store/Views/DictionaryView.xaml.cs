using System;
using System.Collections.Generic;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using FlashCardApp.Core.ViewModels.Dictionary;

using FlashCardApp.Store.Common;

namespace FlashCardApp.Store.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DictionaryView : FlashCardApp.Store.Common.LayoutAwarePage
    {
        public DictionaryView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
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
