using System;
using Xamarin.Forms;

namespace ProjetoReferenciaMultitenantBase.Controls
{
    public class SampleNavigationPage : NavigationPage
    {
        public SampleNavigationPage(Page root) : base(root)
        {
            Init();
            Title = root.Title;
            IconImageSource = root.IconImageSource;
        }

        public SampleNavigationPage()
        {
            Init();
        }

        void Init()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                BarBackgroundColor = (Color)Application.Current.Resources["CornSample"];
                BarTextColor = (Color)Application.Current.Resources["CorPrimaria"];
            }
            else
            {
                BarBackgroundColor = (Color)Application.Current.Resources["CornSample"];
                BarTextColor = (Color)Application.Current.Resources["CorPrimaria"];
            }
        }
    }
}
