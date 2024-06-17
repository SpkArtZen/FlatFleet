using FlatFleet.ViewModels;

namespace FlatFleet;

public partial class TermsOfServicePage : ContentPage
{
	public TermsOfServicePage(TermsOfServiceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}