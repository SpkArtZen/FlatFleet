using FlatFleet.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Shapes;
using System.Windows.Input;

namespace FlatFleet.Pages;

public partial class StatusCheckPage : ContentPage
{
	public StatusCheckPage(StatusCheckViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		viewModel.SelectedStatusChanged += OnSelectedStatusChange;
        viewModel.TenantEmailAdding += TenantEmailAdding;
	}

    /*
     <VerticalStackLayout x:Name="PageLayout">
            <StackLayout Orientation="Horizontal" HorizontalOptions="Center" VerticalOptions="CenterAndExpand" Margin="20">
                <Label
                    Text="Add values "
                    TextColor="{StaticResource AddButtonBlue}"
                    FontSize="16"
                    FontAttributes="Bold"
                    HorizontalOptions="Center">
                </Label>
                <Image Source="plus.png">
                    <Image.GestureRecognizers>
                        <TapGestureRecognizer Command="{Binding AddTenantEmailCommand}"/>
                    </Image.GestureRecognizers>
                </Image>
            </StackLayout>
     */

    private void TenantEmailAdding(object? sender, int num)
    {
        var frame = new Frame()
        {  
            HeightRequest = 48, 
            WidthRequest = 370, 
            Margin = 10,
            Content = new Entry()  
            {
                Placeholder = $"Tenant email #{num}", 
                FontSize = 16,
                HeightRequest = 60,
            }
        }; 
        PageLayout.Children.Add(frame);
    }

    private void OnSelectedStatusChange(object? sender, Status status)
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

    /*
     <Frame
                HeightRequest="48"
                WidthRequest="370"
                Margin="20">
                <Entry
                    Placeholder="Tenant email #1"
                    FontSize="16"
                    HeightRequest="60"/>
     */

    private void LoadTenantEmailsOnPage()
    {
        LoadLineAndLabel("Specify tenant emails confirming your status");

        var firstFrame = new Frame()
        {
            HeightRequest = 48,
            WidthRequest = 370,
            Margin = 10,
            Content = new Entry()
            {
                Placeholder = "Tenant email #1",
                FontSize = 16,
                HeightRequest = 60,
            }
        };
        PageLayout.Children.Add(firstFrame);
        
        var secondFrame = new Frame()
        {
            HeightRequest = 48,
            WidthRequest = 370,
            Margin = 10,
            Content = new Entry()
            {
                Placeholder = "Tenant email #2",
                FontSize = 16,
                HeightRequest = 60,
            }
        };
        PageLayout.Children.Add(secondFrame);

        var viewModel = BindingContext as StatusCheckViewModel;

        var stackLayout = new StackLayout()
        {
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Margin = 20
        };
        stackLayout.Children.Add(new Label
        {
            Text = "Add values ",
            TextColor = Colors.Blue,
            FontAttributes = FontAttributes.Bold,
            FontSize = 16,
            HorizontalOptions = LayoutOptions.Center
        });
        var image = new Image()
        {
            Source = "plus.png"
        };
        image.GestureRecognizers.Add(new TapGestureRecognizer()
        {
            Command = viewModel.AddTenantEmailCommand
        });
        stackLayout.Children.Add(image);

        AddTenantLayout.Children.Add(stackLayout);
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