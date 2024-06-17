using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class ManagementCompanyPage : ContentPage
{
	public ManagementCompanyPage()
	{
		InitializeComponent();
		BindingContext = new ManagementCompanyViewModel();
	}
}