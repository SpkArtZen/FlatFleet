using FlatFleet.ViewModels;

namespace FlatFleet;

public partial class SelectAccountTypePage : ContentPage
{
    public SelectAccountTypePage(SelectAccountTypePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}