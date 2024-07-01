using FlatFleet.Pages;

namespace FlatFleet
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("SignUp", typeof(SignUpPage));
        }
    }
}
