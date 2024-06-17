using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class EntryNewPasswordPage : ContentPage
{
	public EntryNewPasswordPage()
	{
		InitializeComponent();
        BindingContext = new EntryNewPasswordPageViewModel();
    }
}