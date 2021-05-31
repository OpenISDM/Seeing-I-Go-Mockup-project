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
            Console.WriteLine("bbb");
            MainPage = new NavigationPage(new NavigatorPage());
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
