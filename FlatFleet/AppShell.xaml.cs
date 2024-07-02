using FlatFleet.Pages;

namespace FlatFleet
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            /*
              case "//SelectManagementCompany":
                case "//SelectDoubt":
                case "//SelectTenantOfHouse":
                case "//SelectHouseCommittee"
             */


            InitializeComponent();
            Routing.RegisterRoute("GetStarted", typeof(GetStartedPage));
            Routing.RegisterRoute("SignUp", typeof(SignUpPage));
            Routing.RegisterRoute("TermsOfService", typeof(TermsOfServicePage));
            Routing.RegisterRoute("PrivacyPolicy", typeof(PrivacyPolicyPage));
            Routing.RegisterRoute("SelectDoubt", typeof(DoubtPage));
            Routing.RegisterRoute("SelectManagementCompany", typeof(ManagementCompanyPage));
            Routing.RegisterRoute("SelectTenantOfHouse", typeof(TenantOfHousePage));
            Routing.RegisterRoute("SelectHouseCommittee", typeof(HouseCommitteePage));
        }
    }
}
