using Microsoft.Maui.Controls;
using System.Windows.Input;
using Navigation;

namespace FlatFleet;

public partial class SignIn : ContentPage
{
    public ICommand LoginWithGoogleCommand { get; }
    public SignIn()
	{
		InitializeComponent();
        LoginWithGoogleCommand = new Command(OnLoginWithGoogle);
    }
    private async void OnLoginWithGoogle()
    {
        // ��� ��� ������� ����� ����� Google
        await NavigationService.Navigate(typeof(MainPage));
    }
}