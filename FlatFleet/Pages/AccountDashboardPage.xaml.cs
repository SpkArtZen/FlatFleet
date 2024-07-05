using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class AccountDashboardPage : ContentPage
{
	public AccountDashboardPage(AccountDashboardPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}