using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class BuildingLocationViewModel
    {
		private string _homeLocation;

		public string HomeLocation
		{
			get { return _homeLocation; }
			set { _homeLocation = value; }
		}

		private ICommand SubmitCommand { get; }
        
        public BuildingLocationViewModel()
        {
            SubmitCommand = new Command(Submit);
        }

        private async void Submit()
        {
            // TODO: Add route to next page 
            //await Shell.Current.GoToAsync("");
        }
    }
}
