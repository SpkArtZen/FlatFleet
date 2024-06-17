using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class NewPasswordAcceptedPage : ContentPage
{
	public NewPasswordAcceptedPage()
	{
		InitializeComponent();
		BindingContext = new NewPasswordAcceptedViewModel();
	}
}