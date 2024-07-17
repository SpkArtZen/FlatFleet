using MvvmHelpers;
using FlatFleet.Features.Navigation;
using FlatFleet.Pages;
using System.Windows.Input;
using FlatFleet.Features.Services;

namespace FlatFleet.Pages
{
    public class FloorDefinitionViewModel : BaseViewModel
    {
        private string _selectedText = "First floor";
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

        private List<string> _floors;
        public List<string> Floors
        {
            get { return _floors; }
            set
            {
                SetProperty(ref _floors, value);
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
        public ICommand AddApartmentCommand { get; }
        public ICommand RemoveApartmentCommand { get; }
        
        public event EventHandler OnAddApartment;

        public FloorDefinitionViewModel()
        {
            Floors = new()
            {
                "First floor",
                "Second floor",
                "Third floor",
                "Fourth floor"
            };

            SelectedItem = new Command((obj) => SelectedItemAction(obj));
            AddApartmentCommand = new Command(AddApartment);
            RemoveApartmentCommand = new Command(RemoveApartment);
        }

        private void SelectedItemAction(object obj)
        {
            IsOpened = false;
            SelectedText = obj.ToString();
        }

        private void AddApartment()
        {
            OnAddApartment?.Invoke(this, null);
        }

        private void RemoveApartment()
        {

        }
    }
}