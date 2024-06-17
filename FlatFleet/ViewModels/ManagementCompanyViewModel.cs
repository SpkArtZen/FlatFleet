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
        }
        private async void UploadFiles()
        {
            await Shell.Current.GoToAsync("//UploadFiles");
        }
    }
}
