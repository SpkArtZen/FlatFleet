using Microsoft.Maui.Controls;
namespace FlatFleet;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell(); // Це потрібно для навігації за допомогою Shell.Current.GoToAsync("//Page")

    }
   
    protected override async void OnStart()
    {
        await Shell.Current.GoToAsync("//FloorDefinition");
        base.OnStart();
    }
}
