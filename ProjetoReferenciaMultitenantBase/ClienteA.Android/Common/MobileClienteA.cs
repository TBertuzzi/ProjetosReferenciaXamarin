using System;
using ProjetoReferenciaMultitenantBase.Common;

namespace ClienteA.Android.Common
{
    public class MobileClienteA : IMobileCore
    {
        public string Nome => "ClienteA";

        public string AppCenterKey => "chaveDoClienteA-Android";
    }
}
