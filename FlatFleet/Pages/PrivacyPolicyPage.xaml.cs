using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class PrivacyPolicyPage : ContentPage
{
	public PrivacyPolicyPage(PrivacyPolicyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}