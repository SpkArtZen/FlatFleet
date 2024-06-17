using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class RecoverPasswordPage : ContentPage
{
	public RecoverPasswordPage(RecoverPasswordPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}