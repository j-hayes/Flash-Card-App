using Cirrious.CrossCore.IoC;
using FlashCardApp.Core.ViewModels;

namespace FlashCardApp.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Manager")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
			RegisterAppStart<HomePageViewModel>();
        }
    }
}