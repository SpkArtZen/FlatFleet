using FlatFleet.ViewModels;
namespace FlatFleet;

public partial class SelectAccountTypePage : ContentPage
{
	public SelectAccountTypePage()
	{
		InitializeComponent();
		BindingContext = new SelectAccountTypeViewModel();
	}


}