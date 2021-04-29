using System;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using ProjetoReferenciaMultitenantBase.Common;
using ProjetoReferenciaMultitenantBase.Services.Navigation;
using ProjetoReferenciaMultitenantBase.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoReferenciaMultitenantBase
{

    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public App()
        {
            InitializeComponent();

            InitializeMobileTenant();

            InitNavigation();
        }

        private void InitializeMobileTenant()
        {

            IMobileCore mobileCore = App.ServiceProvider.GetService<IMobileCore>();

            var nomeApp = mobileCore.Nome;

            var appCenterConfig = string.Empty;

            switch (Xamarin.Forms.Device.RuntimePlatform)
            {
                case Xamarin.Forms.Device.iOS:
                    appCenterConfig = $"ios={mobileCore.AppCenterKey};";
                    break;
                case Xamarin.Forms.Device.Android:
                    appCenterConfig = $"android={mobileCore.AppCenterKey};";
                    break;
                default:
                    break;
            }

            AppCenter.Start(appCenterConfig,
                        typeof(Analytics), typeof(Crashes), typeof(Distribute));



        }

        async void InitNavigation()
        {
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            await navigationService.InitializeAsync<MainPageViewModel>(null, true);
        }

        private bool OnReleaseAvailable(ReleaseDetails releaseDetails)
        {
            // Look at releaseDetails public properties to get version information, release notes text or release notes URL
            var versionName = releaseDetails.ShortVersion;
            var versionCodeOrBuildNumber = releaseDetails.Version;
            var releaseNotes = releaseDetails.ReleaseNotes;
            var releaseNotesUrl = releaseDetails.ReleaseNotesUrl;

            // custom dialog
            var title = "Versão " + versionName + " disponivel!";
            Task answer;

            // Update Obrigatório
            if (releaseDetails.MandatoryUpdate)
            {
                answer = Current.MainPage.DisplayAlert(title, releaseNotes, "Baixar e instalar");
            }
            else
            {
                answer = Current.MainPage.DisplayAlert(title, releaseNotes, "Baixar e instalar", "Lembre-me mais tarde");
            }
            answer.ContinueWith((task) =>
            {
                if (releaseDetails.MandatoryUpdate || ((Task<bool>)task).Result)
                {
                    Distribute.NotifyUpdateAction(UpdateAction.Update);
                }
                else
                {
                    Distribute.NotifyUpdateAction(UpdateAction.Postpone);
                }
            });

            return true;
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
