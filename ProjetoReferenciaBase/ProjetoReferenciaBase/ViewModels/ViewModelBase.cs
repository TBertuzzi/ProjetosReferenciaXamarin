using System;
using System.Threading.Tasks;
using ProjetoReferenciaBase.MVVM;
using ProjetoReferenciaBase.Services.Dialog;
using ProjetoReferenciaBase.Services.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoReferenciaBase.ViewModels
{
    public class ViewModelBase : ObservableObject
    {

        protected bool HasInitialized { get; set; }

        public event EventHandler IsActiveChanged;

        string title = string.Empty;


        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        string subtitle = string.Empty;


        public string Subtitle
        {
            get => subtitle;
            set => SetProperty(ref subtitle, value);
        }

        string icon = string.Empty;

        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }

        bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;

        public bool IsNotBusy
        {
            get => isNotBusy;
            set
            {
                if (SetProperty(ref isNotBusy, value))
                    IsBusy = !isNotBusy;
            }
        }

        bool canLoadMore = true;

        public bool CanLoadMore
        {
            get => canLoadMore;
            set => SetProperty(ref canLoadMore, value);
        }


        string header = string.Empty;

        public string Header
        {
            get => header;
            set => SetProperty(ref header, value);
        }

        string footer = string.Empty;

        public string Footer
        {
            get => footer;
            set => SetProperty(ref footer, value);
        }

        public virtual Task LoadAsync(NavigationParameters navigationData) => Task.FromResult(false);

        public virtual Task OnNavigate(NavigationParameters navigationData) => Task.FromResult(false);

        public virtual Task ResumeASync() => Task.FromResult(false);

        public virtual void AppLinkRequestReceive(Uri uri) => Task.FromResult(false);

        protected readonly INavigationService NavigationService;
        protected readonly IDialogService DialogService;


        public ViewModelBase()
        {
            NavigationService = App.ServiceProvider.GetService<INavigationService>();
            DialogService = App.ServiceProvider.GetService<IDialogService>();
        }


    }
}
