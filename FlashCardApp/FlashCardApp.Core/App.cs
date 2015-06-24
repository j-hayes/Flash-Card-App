using Cirrious.CrossCore.IoC;
using FlashCardApp.Core.ViewModels;

namespace FlashCardApp.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
               .EndingWith("Manager")
               .AsInterfaces()
               .RegisterAsLazySingleton();

            CreatableTypes()
             .EndingWith("Repository")
             .AsInterfaces()
             .RegisterAsLazySingleton();
				
            RegisterAppStart<HomePageViewModel>();
        }
    }
}