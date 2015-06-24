using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using FlashCardApp.Core.ViewModels;

namespace FlashCardApp.Droid
{

    [Activity(Label = "Dictionary")]
    public class DictionaryView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DictionaryView);
        }
    }

    [Activity(Label = "Study Settings")]
    public class StudyFlashCardSetSettingsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StudyFlashCardSettingsView);
        }
    }

    [Activity(Label = "Read")]
    public class CategoryListView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CategoryListView);
        }
    }
  

    [Activity(Label = "View for Home")]
    public class HomePageView : MvxTabActivity
    {
        protected HomePageViewModel HomePageViewModel
        {
            get { return base.ViewModel as HomePageViewModel; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.HomePageView);


                TabHost.TabSpec spec;
                Intent intent;

                spec = TabHost.NewTabSpec("字典");
                spec.SetIndicator("字典");
                spec.SetContent(this.CreateIntentFor(HomePageViewModel.DictionaryViewModel));
                TabHost.AddTab(spec);

                spec = TabHost.NewTabSpec("学习");
                spec.SetIndicator("学习");
                spec.SetContent(this.CreateIntentFor(HomePageViewModel.StudyFlashCardSetSettingsViewModel));
                TabHost.AddTab(spec);

              
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
