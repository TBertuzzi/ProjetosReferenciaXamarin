using System;
using Xamarin.Forms;
using Xamarin.Forms.MVVMBase;
using Xamarin.Forms.MVVMBase.Services.Navigation;
using ProjetoReferenciaMVVMBase.ViewModels;

namespace ProjetoReferenciaMVVMBase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BuildDependencies();
            InitNavigation();
        }

        public void BuildDependencies()
        {
            Container.Current.RegisterForNavigation<MainPage, MainViewModel>();

            //Configure Container
            Container.Current.Setup();
        }

        async void InitNavigation()
        {
            var navigationService = Container.Current.Resolve<INavigationService>();

            //Basic Startup
            await navigationService.InitializeAsync<MainViewModel>(null, true);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
