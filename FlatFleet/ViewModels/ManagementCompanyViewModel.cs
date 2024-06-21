using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class ManagementCompanyViewModel : BindableObject
    {
        public ICommand AttachFilesCommand { get; set; }
        public ManagementCompanyViewModel() 
        {
            AttachFilesCommand = new Command(UploadFiles);
            GoToPreviousPageCommand = new Command(BackToPrevPage);
        }
        public ICommand GoToPreviousPageCommand { get; }
        private async void BackToPrevPage()
        {
            string currentRoute = Shell.Current.CurrentState.Location.ToString();

            switch (currentRoute)
            {
                case "//RecoverPassword":
                    await Shell.Current.GoToAsync("//SignIn");
                    break;
                case "//SignIn":
                    await Shell.Current.GoToAsync("//GetStarted");
                    break;
                case "//VerifyEmail":
                    await Shell.Current.GoToAsync("//RecoverPassword");
                    break;
                case "//EnterNewPassword":
                    await Shell.Current.GoToAsync("//VerifyEmail");
                    break;
                case "//SelectAccountType":
                    await Shell.Current.GoToAsync("//SignIn");
                    break;
                case "//SelectManagementCompany":
                case "//SelectDoubt":
                case "//SelectTenantOfHouse":
                case "//SelectHouseCommittee":
                case "//UploadFiles":
                    await Shell.Current.GoToAsync("//SelectAccountType");
                    break;
            }
        }
        private async void UploadFiles()
        {
            await Shell.Current.GoToAsync("//UploadFiles");
        }
    }
}
