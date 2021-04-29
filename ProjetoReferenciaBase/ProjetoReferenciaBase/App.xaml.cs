using System;
using ProjetoReferenciaBase.Services.Navigation;
using ProjetoReferenciaBase.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoReferenciaBase
{

    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public App()
        {
            InitializeComponent();

            InitNavigation();
        }

        async void InitNavigation()
        {
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            await navigationService.InitializeAsync<MainPageViewModel>(null, true);
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
