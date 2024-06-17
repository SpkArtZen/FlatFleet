using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class ManagementCompanyPage : ContentPage
{
	public ManagementCompanyPage(ManagementCompanyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}