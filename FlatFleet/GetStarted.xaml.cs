using FlatFleet.ViewModels;

namespace FlatFleet;

public partial class GetStarted : ContentPage
{
    public GetStarted()
    {
        InitializeComponent();
        BindingContext = new GetStartedViewModel();
    }
    private async void GetStartedBtn_click(object sender, EventArgs e)
    {
        if (BindingContext is GetStartedViewModel viewModel)
        {
            viewModel.GetStartedCommand.Execute(null);
        }
        else
        {
            throw new Exception();
        }
    }
}