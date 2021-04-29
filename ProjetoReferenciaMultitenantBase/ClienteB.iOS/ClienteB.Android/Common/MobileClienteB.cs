using System;
using ProjetoReferenciaMultitenantBase.Common;

namespace ClienteB.Android.Common
{
    public class MobileClienteB : IMobileCore
    {
        public string Nome => "ClienteB";

        public string AppCenterKey => "chaveDoClienteB-Android";
    }
}
