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
				LoadFirstTenantOnPage();
				break;
			case Status.VOTE:
				LoadTenantEmailsOnPage();
				break;
			case Status.UNDEFINED:
				break;
		}
	}

    private void LoadTenantEmailsOnPage()
    {
        LoadLineAndLabel("Specify tenant emails confirming your status");

        var frame = new Frame()
        {
            HeightRequest = 48,
            WidthRequest = 370,
            Margin = 20,
        };
        frame.Content = new Entry() 
        {
            Placeholder = "Tenant email #1"
        };
        PageLayout.Children.Add(frame);
    }

    private void LoadFirstTenantOnPage()
    {
        LoadLineAndLabel("The system will check if you are the only tenant of");
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

        LoadLineAndLabel("Attach documents providing your status");

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

    private void LoadLineAndLabel(string labelText)
    {
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
            Text = labelText,
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 15,
        };
        PageLayout.Children.Add(label);
    }
}