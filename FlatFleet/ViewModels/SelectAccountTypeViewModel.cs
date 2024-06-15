using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FlatFleet.ViewModels
{
    public class SelectAccountTypeViewModel : BindableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _selectedText = "Select the item";
        public string SelectedText
        {
            get { return _selectedText; }
            set
            {
                if (_selectedText != value)
                {
                    _selectedText = value;
                    OnPropertyChanged(nameof(SelectedText));
                }
            }
        }

        private bool _isOpened;
        public bool IsOpened
        {
            get { return _isOpened; }
            set
            {
                if (_isOpened != value)
                {
                    _isOpened = value;
                    OnPropertyChanged(nameof(IsOpened));
                }
            }
        }

        private List<string> _types;
        public List<string> TypesOfAccount
        {
            get { return _types; }
            set
            {
                if (_types != value)
                {
                    _types = value;
                    OnPropertyChanged(nameof(TypesOfAccount));
                }
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
