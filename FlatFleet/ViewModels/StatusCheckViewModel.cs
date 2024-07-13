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
    private int _tenantNumber = 3;
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

    private Dictionary<Status, string?> _statusVal = new()
    {
        { Status.DOCUMENT, "I have a document" },
        { Status.FIRST_TENANT, "I am the first tenent to install app" },
        { Status.VOTE, "I was elected by vote" },
        { Status.UNDEFINED, null }
    };

    private string _selectedText = "Select";
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
    public ICommand UploadFilesCommand { get; }
    public ICommand AddTenantEmailCommand { get; }

    public StatusCheckViewModel()
    {
        TypesOfStatus = _statusVal.Values.ToList();
        SelectedItem = new Command((obj) => SelectedItemAction(obj));
        SubmitCommand = new Command(Submit);
        UploadFilesCommand = new Command(UploadFiles);
        AddTenantEmailCommand = new Command(AddTenantEmail);
    }

    public event EventHandler <Status>? SelectedStatusChanged;
    public event EventHandler <int>? TenantEmailAdding;

    private void SelectedItemAction(object obj)
    {
        IsOpened = false;
        SelectedText = obj.ToString();
        SelectedStatusChanged?.Invoke(this, SelectedStatus);
    }

    private void AddTenantEmail()
    {
        TenantEmailAdding?.Invoke(this, _tenantNumber);
        _tenantNumber++;
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
                await Shell.Current.GoToAsync("//AccountDashboard");
                break;

        }
    }

    private async void UploadFiles()
    {
        await Shell.Current.GoToAsync("UploadFiles");
    }
}
