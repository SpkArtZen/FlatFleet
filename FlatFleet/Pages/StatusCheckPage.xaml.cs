using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class StatusCheckPage : ContentPage
{
	public StatusCheckPage(StatusCheckViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}