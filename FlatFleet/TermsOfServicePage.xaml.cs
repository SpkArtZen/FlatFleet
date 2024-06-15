namespace FlatFleet;

public partial class TermsOfServicePage : ContentPage
{
	public TermsOfServicePage()
	{
		InitializeComponent();
		BindingContext = new TermsOfServiceViewModel();
	}
}