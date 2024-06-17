using FlatFleet.ViewModels;

namespace FlatFleet;

public partial class PrivacyPolicyPage : ContentPage
{
	public PrivacyPolicyPage(PrivacyPolicyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}