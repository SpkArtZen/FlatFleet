using MvvmHelpers;
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
        }

        private void SelectedItemAction(object obj)
        {
            IsOpened = false;          
            IsSelected = "\u2713";
            SelectedText = obj.ToString();          
        }
        private async void UploadFiles()
        {
            await Shell.Current.GoToAsync("//UploadFiles");
        }
    }
}
