using FlatFleet.ViewModels;

namespace FlatFleet;

public partial class RecoverPasswordPage : ContentPage
{
	public RecoverPasswordPage(RecoverPasswordPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}