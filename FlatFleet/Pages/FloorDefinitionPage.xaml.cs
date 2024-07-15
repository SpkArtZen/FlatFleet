namespace FlatFleet.Pages;

public partial class FloorDefinitionPage : ContentPage
{
	public FloorDefinitionPage(FloorDefinitionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}