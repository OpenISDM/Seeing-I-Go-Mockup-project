using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Seeing_I_Go_toy_project.ViewModels;
namespace Seeing_I_Go_toy_project.Views.Pages
{
    public partial class NavigatorPage : ContentPage
    {
        private NavigatorPageViewModel _viewmodel;
        public NavigatorPage()
        {
            InitializeComponent();
            
            Console.WriteLine(">>NavigatorPage : constructor");

            _viewmodel = new NavigatorPageViewModel();
            BindingContext = _viewmodel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //BindingContext = _viewmodel;
        }
    }
}