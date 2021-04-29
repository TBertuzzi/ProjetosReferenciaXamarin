using Android.App;
using ProjetoReferenciaMultitenantBase.Android.Core;
using ProjetoReferenciaMultitenantBase.Common;
using Android.Content.PM;
using ClienteA.Android.Common;

namespace ClienteA.Android
{
    [Activity(Label = "Cliente A", Icon = "@mipmap/ic_launcher",
         Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MainActivityBase
    {
        protected override IMobileCore MobileCore => new MobileClienteA();
    }
}
