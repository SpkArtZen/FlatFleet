using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class BuildingDefinitionsPage : ContentPage
{
	public BuildingDefinitionsPage(BuildingDefinitionsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}