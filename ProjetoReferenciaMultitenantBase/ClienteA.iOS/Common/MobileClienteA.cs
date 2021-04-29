using System;
using ProjetoReferenciaMultitenantBase.Common;

namespace ClienteA.iOS.Common
{
    public class MobileClienteA : IMobileCore
    {
        public string Nome => "ClienteA";

        public string AppCenterKey => "chaveDoClienteA-iOS";
    }
}
