using FlatFleet.ViewModels;

namespace FlatFleet;

public partial class EntryNewPasswordPage : ContentPage
{
	public EntryNewPasswordPage()
	{
		InitializeComponent();
        BindingContext = new EntryNewPasswordPageViewModel();
    }
}