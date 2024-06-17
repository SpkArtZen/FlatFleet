using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class TermsOfServicePage : ContentPage
{
	public TermsOfServicePage(TermsOfServiceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}