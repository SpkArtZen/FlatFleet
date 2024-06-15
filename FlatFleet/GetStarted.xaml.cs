namespace FlatFleet;

public partial class GetStarted : ContentPage
{
	public GetStarted()
	{
		InitializeComponent();
        BindingContext = new Model();
    }
    private async void GetStartedBtn_click(object sender, EventArgs e)
	{
        if (BindingContext is Model viewModel)
        {
            viewModel.GetStartedCommand.Execute(null);
        }
        else
        {
            throw new Exception();
        }
    }
}