using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class TenantOfHousePage : ContentPage
{
	public TenantOfHousePage(TenantOfHousePageViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}