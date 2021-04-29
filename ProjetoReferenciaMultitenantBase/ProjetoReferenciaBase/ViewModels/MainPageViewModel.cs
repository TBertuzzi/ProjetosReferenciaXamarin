using System;
using ProjetoReferenciaMultitenantBase.Common;

namespace ProjetoReferenciaMultitenantBase.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _cliente;
        public string Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value);
        }

        public MainPageViewModel(IMobileCore mobileCore)
        {
            this.Title = "ViewModel de Exemplo";

            Cliente = mobileCore.Nome;


        }
    }
}
