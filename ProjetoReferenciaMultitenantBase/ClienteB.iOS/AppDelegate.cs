using ClienteB.iOS.Common;
using Foundation;
using ProjetoReferenciaMultitenantBase.Common;
using ProjetoReferenciaMultitenantBase.iOS.Core;
using UIKit;

namespace ClienteB.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : AppDelegateBase
    {
        protected override IMobileCore MobileCore => new MobileClienteA();
    }
}

