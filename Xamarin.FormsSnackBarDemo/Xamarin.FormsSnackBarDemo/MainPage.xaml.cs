using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Xamarin.FormsSnackBarDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SnackB.IsOpen = !SnackB.IsOpen;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var pageSafeArea = On<iOS>().SafeAreaInsets();
            SnackB.Padding = new Thickness(0, 0, 0, pageSafeArea.Bottom);
        }
    }
}
