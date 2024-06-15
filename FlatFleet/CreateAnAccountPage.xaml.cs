namespace FlatFleet
{
	public partial class CreateAnAccountPage : ContentPage
	{
		public CreateAnAccountPage()
		{
			InitializeComponent();
			BindingContext = new CreateAnAccountViewModel();
        }
	}
}