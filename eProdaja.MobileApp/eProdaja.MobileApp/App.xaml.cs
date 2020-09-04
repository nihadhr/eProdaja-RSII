using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eProdaja.MobileApp.Services;
using eProdaja.MobileApp.Views;

namespace eProdaja.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
