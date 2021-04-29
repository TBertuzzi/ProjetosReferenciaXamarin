using Foundation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoReferenciaMultitenantBase.Common;
using UIKit;
using Xamarin.Forms;

namespace ProjetoReferenciaMultitenantBase.iOS.Core
{
    public abstract partial class AppDelegateBase : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        protected abstract IMobileCore MobileCore { get; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.SetFlags("AppTheme_Experimental");
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(Startup.Init(ConfigureServices));

            return base.FinishedLaunching(app, options);
        }

        void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddSingleton(MobileCore);
        }

    }
}
