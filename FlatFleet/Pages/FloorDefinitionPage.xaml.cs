namespace FlatFleet.Pages;

public partial class FloorDefinitionPage : ContentPage
{
	public FloorDefinitionPage(FloorDefinitionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        viewModel.OnAddApartment += AddApartment;
	}

	private void AddApartment(object? sender, EventArgs e)
	{
		var viewModel = BindingContext as FloorDefinitionViewModel;

        var horizontalLayout = new HorizontalStackLayout
        {
            Spacing = 10,
            Padding = new Thickness(10, 0, 10, 10)
        };
    
        var apartmentFrame = new Frame
        {
            WidthRequest = 152,
            HeightRequest = 48,
            Margin = 10
        };

        var inhabitantsFrame = new Frame
        {
            WidthRequest = 152,
            HeightRequest = 48,
        };

        var closeIcon = new Image
        {
            Source = "close_icon_outline.png",
            GestureRecognizers =
                {
                    new TapGestureRecognizer() { Command = viewModel.RemoveApartmentCommand }
                }
        };

        horizontalLayout.Children.Add(apartmentFrame);
        horizontalLayout.Children.Add(inhabitantsFrame);
        horizontalLayout.Children.Add(closeIcon);

        VerticalLayout.Children.Add(horizontalLayout);
    }
}