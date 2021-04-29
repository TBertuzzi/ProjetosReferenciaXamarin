using Android.App;
using ProjetoReferenciaMultitenantBase.Android.Core;
using ProjetoReferenciaMultitenantBase.Common;
using ClienteB.Android.Common;
using Android.Content.PM;

namespace ClienteB.Android
{
    [Activity(Label = "Cliente B", Icon = "@mipmap/ic_launcher",
       Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MainActivityBase
    {
        protected override IMobileCore MobileCore => new MobileClienteB();
    }
}
