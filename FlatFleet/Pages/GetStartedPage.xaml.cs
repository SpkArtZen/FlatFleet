using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class GetStartedPage : ContentPage
{
    public GetStartedPage(GetStartedViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}