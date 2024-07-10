using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{

    public class TenantOfHousePageViewModel : BaseViewModel
    {
        public ICommand GoToMapCommand {  get; set; }
        public ICommand GoToQRReaderCommand { get; set; }
        public TenantOfHousePageViewModel() {
            GoToMapCommand = new Command(GoToMap);
            GoToQRReaderCommand = new Command(GoToQRReader);
        }
        public async void GoToMap()
        {
            await Shell.Current.GoToAsync("///ConfirmAdressOnMap");
        }
        public async void GoToQRReader()
        {
            await Shell.Current.GoToAsync("///QRScanner");
        }
    }
}
