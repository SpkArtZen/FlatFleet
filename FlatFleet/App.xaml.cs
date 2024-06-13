using Microsoft.Maui.Controls;
namespace FlatFleet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); // Встановлення головної сторінки з навігацією
        }
    }
}
