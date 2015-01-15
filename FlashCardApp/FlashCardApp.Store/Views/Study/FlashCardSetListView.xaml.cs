// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234
using System;
using System.Collections.Generic;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cirrious.MvvmCross.WindowsStore.Views;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.ViewModels.Study;
using FlashCardApp.Store.Common;

namespace FlashCardApp.Store.Views.Study
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for
    /// the currently selected item.
    /// </summary>
    public sealed partial class FlashCardSetListView : MvxStorePage
    {
        public FlashCardSetListView()
        {
            this.InitializeComponent();
        }

        public FlashCardSetListViewModel viewModel { get { return ((FlashCardSetListViewModel) ViewModel); } }

        /// <summary>
        /// Invoked when an item within the list is selected.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is Snapped)
        /// displaying the selected item.</param>
        /// <param name="e">Event data that describes how the selection was changed.</param>
        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ((FlashCardSetListViewModel) ViewModel).SelectedSet = (FlashCardSet) e.AddedItems[0];
            }
        }

    }
}
