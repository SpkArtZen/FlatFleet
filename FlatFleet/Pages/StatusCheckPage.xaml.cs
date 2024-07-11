using FlatFleet.ViewModels;

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
	 */

    private void LoadFileUploadOnPage()
    {
		var viewModel = BindingContext as StatusCheckViewModel;
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