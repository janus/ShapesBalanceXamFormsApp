using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShapesBalanceXamFormsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            double[] percentages = {15.0, 15.0, 10.0, 10.0};
            MainPage = new ContentPage {
                Content = new MainPage().makePies(percentages)
            };

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
