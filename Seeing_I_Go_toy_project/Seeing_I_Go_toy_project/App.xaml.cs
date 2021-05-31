using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Seeing_I_Go_toy_project.Views.Pages;
namespace Seeing_I_Go_toy_project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            NavigationPage _navigationPage = new NavigationPage(new NavigatorPage());
            _navigationPage.BarBackgroundColor = Color.FromHex("#3f51b5");
            _navigationPage.BarTextColor = Color.White;
            MainPage = _navigationPage;
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
