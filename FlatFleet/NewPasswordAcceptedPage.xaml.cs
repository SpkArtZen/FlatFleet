namespace FlatFleet;

public partial class NewPasswordAcceptedPage : ContentPage
{
	public NewPasswordAcceptedPage()
	{
		InitializeComponent();
		BindingContext = new NewPasswordAcceptedViewModel();
	}
}