using System;
using ProjetoReferenciaMultitenantBase.Common;

namespace ClienteB.iOS.Common
{
    public class MobileClienteA : IMobileCore
    {
        public string Nome => "ClienteB";

        public string AppCenterKey => "chaveDoClienteB-iOS";
    }
}
