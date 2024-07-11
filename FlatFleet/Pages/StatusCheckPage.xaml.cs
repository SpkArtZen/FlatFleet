using FlatFleet.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace FlatFleet.Pages;

public partial class StatusCheckPage : ContentPage
{
	public StatusCheckPage(StatusCheckViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		viewModel.SelectedStatusChanged += OnSelectedStatusChange;
	}

	private void OnSelectedStatusChange(object sender, Status status)
	{
		PageLayout.Children.Clear();
		switch (status) 	
		{ 
			case Status.DOCUMENT:
				LoadFileUploadOnPage();
				break;
			case Status.FIRST_TENANT:
			case Status.VOTE:
			case Status.UNDEFINED:
				break;
		}
	}

    /*
	 <Image.GestureRecognizers>
                    <TapGestureRecognizer Command="{Binding UploadFilesCommand}"></TapGestureRecognizer>
                </Image.GestureRecognizers>

	<Line Stroke="LightGray" X1="16" X2="375" Y1="20" Y2="20" HorizontalOptions="Fill" StrokeThickness="1"/>
            <Label 
                TextColor="DimGray"
                Text="Attach documents providing your status"
                HorizontalOptions="Center"
                FontSize="15"/>
	 */

    private void LoadFileUploadOnPage()
    {
		var viewModel = BindingContext as StatusCheckViewModel;

		var line = new Line()
		{
			Stroke = Colors.LightGray,
			X1 = 16,
			X2 = 375,
			Y1 = 20,
			Y2 = 20,
			HorizontalOptions = LayoutOptions.Fill,
			StrokeThickness = 1
		};
		PageLayout.Children.Add(line);

		var label = new Label()
		{
			TextColor = Colors.DimGray,
			Text = "Attach documents providing your status",
			HorizontalOptions = LayoutOptions.Center,
			FontSize = 15,
		};
		PageLayout.Children.Add(label);

		var image = new Image()
		{
			Source = "@string/attach_files_icon.png",
			HeightRequest = 60,
			WidthRequest = 60,
			Margin = 10,
        };
		image.GestureRecognizers.Add(new TapGestureRecognizer { Command = viewModel.UploadFilesCommand });
		PageLayout.Children.Add(image);
		
		SubmitButton.Text = "Complete onboarding";
    }
}