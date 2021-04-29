using System;
using System.Threading.Tasks;
using ProjetoReferenciaMultitenantBase.ViewModels;

namespace ProjetoReferenciaMultitenantBase.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync<TViewModel>(NavigationParameters parameters = null, bool navigationPage = false) where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(NavigationParameters parameters) where TViewModel : ViewModelBase;
        Task NavigateToAsync(Type viewModelType);
        Task NavigateToAsync(Type viewModelType, NavigationParameters parameters);
        Task NavigateBackAsync(NavigationParameters parameters = null);
        Task NavigateParentBackAsync(NavigationParameters parameters = null);
        Task NavigateAndClearBackStackAsync<TViewModel>(NavigationParameters parameters = null, bool animated = false) where TViewModel : ViewModelBase;
        Task PushModalToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task PushModalToAsync<TViewModel>(NavigationParameters parameters) where TViewModel : ViewModelBase;
        Task NavigateUriAsync(Uri uri, bool clearBackStack, NavigationParameters parameters = null);
    }
}
