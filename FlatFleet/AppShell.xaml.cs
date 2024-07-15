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
            Routing.RegisterRoute("RecoverPassword", typeof(RecoverPasswordPage));
            Routing.RegisterRoute("EntryNewPassword", typeof(EntryNewPasswordPage));

            Routing.RegisterRoute("SelectAccountType", typeof(SelectAccountTypePage));
            Routing.RegisterRoute("SelectDoubt", typeof(DoubtPage));
            Routing.RegisterRoute("SelectManagementCompany", typeof(ManagementCompanyPage));
            Routing.RegisterRoute("SelectTenantOfHouse", typeof(TenantOfHousePage));
            Routing.RegisterRoute("BuildingLocation", typeof(BuildingLocationPage));

            Routing.RegisterRoute("UploadFiles", typeof(UploadFilesPage));
            Routing.RegisterRoute("StatusCheck", typeof(StatusCheckPage));

            Routing.RegisterRoute("FloorDefinition", typeof(FloorDefinitionPage));
        }
    }
}
