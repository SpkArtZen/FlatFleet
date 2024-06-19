using Camera.MAUI;
using CommunityToolkit.Maui.Views;
using FlatFleet.Models;
using FlatFleet.ViewModels;

namespace FlatFleet.Pages;

public partial class UploadFilesPage : ContentPage
{
	public UploadFilesPage(UploadFilesViewModel viewModel)
    {
		InitializeComponent();
		BindingContext = viewModel;

        viewModel.CurrPage = this;
        
        viewModel.FilesLoaded += OnFilesLoaded;
    }

    private void OnFilesLoaded(object? sender, List<FileItem> files)
    {
        // Нащо це потрібно?
        //FilesStackLayout.Children.Clear();

        if (files.Count > 1)
        {
            var expander = CreateExpander(files);
            FilesStackLayout.Children.Add(expander);
        }
        else if (files.Count == 1)
        {
            var singleFileView = CreateSingleFileView(files.First());
            FilesStackLayout.Children.Add(singleFileView);
        }
    }
    private View CreateExpander(List<FileItem> files)
    {
        var expander = new Expander
        {

            Header = new Grid
            {
                BackgroundColor = Colors.LightGray,
                Children =
                    {
                        new Frame
                        {
                            CornerRadius = 360,
                            Padding = 0,
                            WidthRequest = 46,
                            HeightRequest = 46,
                            HorizontalOptions = LayoutOptions.Start,
                            Content = new Image                          
                            {
                                Source = "folder.png",
                                WidthRequest = 46,
                                HeightRequest = 46,
                                HorizontalOptions = LayoutOptions.Start
                                
                            }
                        },

                        new VerticalStackLayout
                        {
                            Margin = new Thickness(50,10,10,10),
                            Children =
                            {
                                 new Label { Text = "Multiple files", FontSize = 16, VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.Start },
                                 new Label { Text = $"{files.Count} files", FontSize = 14, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center }
                            }
                        }

                    }
            }
        };

        var stackLayout = new StackLayout();
        foreach (var file in files)
        {
            stackLayout.Children.Add(CreateSingleFileView(file));
        }
        expander.Content = stackLayout;
        return expander;
    }

    private View CreateSingleFileView(FileItem file)
    {
        return new Grid
        {
            Children =
                {
                    new Image { Source = "document.png", WidthRequest = 24, HeightRequest = 24 },
                    new Label { Text = file.Title, FontSize = 16, VerticalOptions = LayoutOptions.Center },
                    new Label { Text = file.Size, FontSize = 14, HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center },
                    new Image { Source = "delete.png", WidthRequest = 24, HeightRequest = 24, HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center }
                }
        };
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();
    }
}
