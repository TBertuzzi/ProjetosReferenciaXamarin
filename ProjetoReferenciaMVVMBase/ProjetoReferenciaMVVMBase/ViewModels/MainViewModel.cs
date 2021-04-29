using System;
using System.Threading.Tasks;
using Xamarin.Forms.MVVMBase.Services.Navigation;
using Xamarin.Forms.MVVMBase.ViewModels;

namespace ProjetoReferenciaMVVMBase.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel() : base("Main View")
        {

        }

        //Override Load
        public override async Task LoadAsync(NavigationParameters navigationData)
        {
        }

        //Override OnNavigate
        public override async Task OnNavigate(NavigationParameters navigationData)
        {
            if (navigationData.NavigationState == NavigationState.Backward)
            {
                //you can use the navigation to identify whether you have returned from a viewmodel
            }

            if (navigationData.NavigationState == NavigationState.Forward)
            {
                //you can use the navigation to identify whether you have navigated to a viewmodel
            }
        }

    }
}
