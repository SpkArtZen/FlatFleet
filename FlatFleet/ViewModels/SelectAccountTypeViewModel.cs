using CommunityToolkit.Maui.ImageSources;
using MvvmHelpers;
using Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class SelectAccountTypeViewModel : BaseViewModel
    {
        public string _searchIcon = "";
        public string SearchIcon
        {
            get { return _searchIcon; }
            set
            {
                SetProperty(ref _searchIcon, value);
            }
        }

        private string _selectedText = "Select the item";
        public string SelectedText
        {
            get { return _selectedText; }
            set
            {
                SetProperty(ref _selectedText, value);
            }
        }

        private bool _isOpened;
        public bool IsOpened
        {
            get { return _isOpened; }
            set
            {
                SetProperty(ref _isOpened, value);
            }
        }

        private List<string> _types;
        public List<string> TypesOfAccount
        {
            get { return _types; }
            set
            {
                SetProperty(ref _types, value);
            }
        }

        private string _isSelected = "";
        public string IsSelected
        {
            get { return _isSelected; }
            set
            {
                SetProperty(ref _isSelected, value);
            }
        }

        public ICommand SelectedItem { get; }
        public ICommand ContinueWithThisTypeCommand { get; private set; }

        public SelectAccountTypeViewModel()
        {
            TypesOfAccount = new List<string>
            {
                "House committee",
                "Management company",
                "The tenant of the house",
                "Doubt"
            };

            SelectedItem = new Command((obj) => SelectedItemAction(obj));
            ContinueWithThisTypeCommand = new Command(ContinueWithDefaultPage);
        }

        private void SelectedItemAction(object obj)
        {
            IsOpened = false;
            SearchIcon = "\U0001F50E";
            IsSelected = "\u2713";
            SelectedText = obj.ToString();

            if (SelectedText == "Management company")
            {
                ContinueWithThisTypeCommand = new Command(ContinueWithCompanyPage);
            }
            else
            {
                ContinueWithThisTypeCommand = new Command(ContinueWithDefaultPage);
            }

            OnPropertyChanged(nameof(ContinueWithThisTypeCommand));
        }

        private async void ContinueWithCompanyPage()
        {
            await NavigationService.NavigateTo(typeof(ManagementCompanyPage));
        }

        private async void ContinueWithDefaultPage()
        {
            await NavigationService.NavigateTo(typeof(MainPage));
        }
    }
}
