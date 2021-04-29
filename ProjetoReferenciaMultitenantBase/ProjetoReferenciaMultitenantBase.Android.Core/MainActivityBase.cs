using System;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoReferenciaMultitenantBase.Common;

namespace ProjetoReferenciaMultitenantBase.Android.Core
{
    public abstract class MainActivityBase : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected abstract IMobileCore MobileCore { get; }

        protected override void OnCreate(Bundle bundle)
        {
            ResourceIdManager.UpdateIdValues();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Essentials.Platform.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(Startup.Init(ConfigureServices));
        }

        void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddSingleton(MobileCore);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
