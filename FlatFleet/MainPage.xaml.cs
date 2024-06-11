using Navigation;

 
namespace FlatFleet
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public async void OnSignInBtn_Click(object sender, EventArgs e)
        {
            await NavigationService.Navigate(typeof(SignIn));
        }
    }

}
