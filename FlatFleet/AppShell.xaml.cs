using FlatFleet.Pages;

namespace FlatFleet
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("GetStarted", typeof(GetStartedPage));
            Routing.RegisterRoute("SignUp", typeof(SignUpPage));
            Routing.RegisterRoute("TermsOfService", typeof(TermsOfServicePage));
            Routing.RegisterRoute("PrivacyPolicy", typeof(PrivacyPolicyPage));
        }
    }
}
