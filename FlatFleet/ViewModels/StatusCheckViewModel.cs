using MvvmHelpers;
using System.Windows.Input;

namespace FlatFleet.ViewModels;

public enum Status
{
    DOCUMENT,
    FIRST_TENANT,
    VOTE,
    UNDEFINED
}

public class StatusCheckViewModel : BaseViewModel
{
    private List<string> _statuses; 
    public List<string> TypesOfStatus
    {
        get => _statuses;
        set
        {
            if (_statuses != value)
            {
                _statuses = value;
                SetProperty(ref _statuses, value);
            }
        }
    }

    private static Dictionary<Status, string> _statusVal = new()
    {
        { Status.DOCUMENT, "I have a document" },
        { Status.FIRST_TENANT, "I am the first tenent to install app" },
        { Status.VOTE, "I was elected by vote" },
        { Status.UNDEFINED, "Select" }
    };

    private string _selectedText = _statusVal.GetValueOrDefault(Status.UNDEFINED);
    public string SelectedText
    {
        get { return _selectedText; }
        set
        {
            _selectedStatus = _statusVal.FirstOrDefault(x => x.Value == value).Key;
            SetProperty(ref _selectedText, value);
            OnPropertyChanged(nameof(SelectedText));
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


    private Status _selectedStatus;
    public Status SelectedStatus
    {
        get => _selectedStatus;
        set => SetProperty(ref _selectedStatus, value);
    }


    public ICommand SubmitCommand { get; }
    public ICommand SelectedItem { get; }
    public ICommand ContinueWithThisTypeCommand { get; private set; }

    public StatusCheckViewModel()
    {
        TypesOfStatus = _statusVal.Values.ToList();
        SelectedItem = new Command((obj) => SelectedItemAction(obj));
        SubmitCommand = new Command(Submit);
    }

    private void SelectedItemAction(object obj)
    {
        IsOpened = false;
        SelectedText = obj.ToString();

        switch (SelectedText)
        {
            /*case "Management company":
                ContinueWithThisTypeCommand = new Command(ContinueWithCompanyPage);
                break;
            case "The tenant of the house":
                ContinueWithThisTypeCommand = new Command(ContinueWithTenantPage);
                break;
            case "Doubt":
                ContinueWithThisTypeCommand = new Command(ContinueWithDoubt);
                break;
            case "House committee":
                ContinueWithThisTypeCommand = new Command(ContinueWithHouseCommittee);
                break;
            default:
                ContinueWithThisTypeCommand = new Command(ContinueWithDefaultPage);
                break;*/
        }
        OnPropertyChanged(nameof(ContinueWithThisTypeCommand));
    }

    private async void Submit()
    {
        switch(SelectedStatus)
        {
            case Status.UNDEFINED:
                await Application.Current.MainPage.DisplayAlert("Error", "Please, select the suitng case", "Ok");
                break;
            case Status.DOCUMENT:
            case Status.FIRST_TENANT:
            case Status.VOTE:
                await Shell.Current.GoToAsync("AccountDashboard");
                break;

        }
    }

}
