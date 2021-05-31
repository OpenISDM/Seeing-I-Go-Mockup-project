using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace Seeing_I_Go_toy_project.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBar : ContentView
    {
        public ProgressBar()
        {
            InitializeComponent();
            WidthOfContainer = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (ProgressProperty.PropertyName == propertyName)
            {
                SetProgressBar();
            }
        }

        private void SetProgressBar()
        {
            Container.Children.Clear();

            double progress = NormalizeValue(Progress);

            Console.WriteLine(progress);
            Console.WriteLine("wwwwwww");

            if (progress < 100)
            {
                Container.Children.Add(new BoxView
                {
                    Color = ProgressColor,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    WidthRequest = (double)(/*Container.Width*/WidthOfContainer * (progress / 100))
                });
            }
            else
            {
                Container.Children.Add(new BoxView
                {
                    Color = ProgressColor,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                });
            }
        }

        public double NormalizeValue(double value)
        {
            if (value <= 0) value = 0.0000000001;
            //this to avoid "NaN is not a Number" Exception on GridLength = 0* 
            if (value >= 100) value = 100;
            return value;
        }

        #region Propertys
        private BoxView _pregressColor;
        private double WidthOfContainer;
        public Color ProgressColor
        {
            get { return (Color)GetValue(ProgressColorProperty); }
            set { SetValue(ProgressColorProperty, value); }
        }
        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public Color backgroundColor
        {
            get { return (Color)GetValue(backgroundColorProperty); }
            set { SetValue(backgroundColorProperty, value); }
        }
        //TODO : I can't find out the namespace "Xamarin.CustomControls", so I change "ProgressBarView" to "ProgressBar".
        public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(ProgressBar), Color.Blue);
        public static readonly BindableProperty backgroundColorProperty = BindableProperty.Create(nameof(backgroundColor), typeof(Color), typeof(ProgressBar), Color.Transparent);
        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(double), typeof(ProgressBar), default(double));
        #endregion
    }
}