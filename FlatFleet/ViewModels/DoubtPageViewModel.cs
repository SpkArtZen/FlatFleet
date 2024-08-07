﻿using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class DoubtPageViewModel : BaseViewModel
    {
        private string _selectedText = "Your profession";
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
        public List<string> TypesOfProfessions
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
        public ICommand UploadFilesCommand { get; }
        
        public ICommand CompleteOnboardingCommand { get; }
        public DoubtPageViewModel()
        {
            UploadFilesCommand = new Command(UploadFiles);
            TypesOfProfessions = new List<string>
            {
                "Profession1",
                "Profession2",
                "Profession3",
                "Profession4"
            };

            SelectedItem = new Command((obj) => SelectedItemAction(obj));
            GoToPreviousPageCommand = new Command(BackToPrevPage);
            CompleteOnboardingCommand = new Command(CompleteOnboarding);
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

        private void SelectedItemAction(object obj)
        {
            IsOpened = false;          
            IsSelected = "\u2713";
            SelectedText = obj.ToString();          
        }

        private async void UploadFiles()
        {
            await Shell.Current.GoToAsync("UploadFiles");
        }

        private async void CompleteOnboarding()
        {
            await Shell.Current.GoToAsync("//AccountDashboard");
        }
    }
}
