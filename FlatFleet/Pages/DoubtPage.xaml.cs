using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class DoubtPage : ContentPage
{
	public DoubtPage(DoubtPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}