using MvvmHelpers;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FlatFleet.ViewModels
{
    public class SelectAccountTypeViewModel : BaseViewModel
    { 
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

        public Command SelectedItem
        {
            get
            {
                return new Command((obj) => SelectedItemAction(obj));
            }
        }

        private void SelectedItemAction(object obj)
        {
            IsOpened = false;
            SelectedText = obj.ToString();
        }

        public SelectAccountTypeViewModel()
        {
            TypesOfAccount = new List<string>
            {
                "House committee",
                "Management company",
                "The tenant of the house",
                "Doubt"
            };
        }
    }
}
