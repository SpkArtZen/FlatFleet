using Microsoft.Maui.Controls;
namespace FlatFleet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Colors.Transparent,
                BarTextColor = Colors.White
            };

            MainPage = navPage;
        }
    }
}
