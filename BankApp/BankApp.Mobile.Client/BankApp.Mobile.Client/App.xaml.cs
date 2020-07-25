using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BankApp.Mobile.Client.Services;
using BankApp.Mobile.Client.Views;

namespace BankApp.Mobile.Client
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
