namespace FlatFleet;

public partial class RecoverPasswordPage : ContentPage
{
	public RecoverPasswordPage()
	{
		InitializeComponent();
		BindingContext = new Model();
	}
}