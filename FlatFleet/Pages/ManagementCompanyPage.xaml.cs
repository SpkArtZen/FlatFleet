using FlatFleet.ViewModels;

namespace FlatFleet;

public partial class ManagementCompanyPage : ContentPage
{
	public ManagementCompanyPage()
	{
		InitializeComponent();
		BindingContext = new ManagementCompanyViewModel();
	}
}