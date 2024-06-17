using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FlatFleet.Models;
using Microsoft.Maui.Controls;
using MvvmHelpers;

namespace FlatFleet.ViewModels
{
    public class GetStartedViewModel : ViewModelBase
    {
        private ObservableCollection<CarouselItem> _carouselItemsIds;
        public ObservableCollection<CarouselItem> CarouselItemsIds
        {
            get => _carouselItemsIds;
            set
            {
                if (_carouselItemsIds != value)
                {
                    _carouselItemsIds = value;
                    OnPropertyChanged(nameof(CarouselItemsIds));
                }
            }
        }
        public ICommand GetStartedCommand { get; }


        public GetStartedViewModel()
        {
            CarouselItemsIds = new()
            {
                new CarouselItem(1),
                new CarouselItem(2),
                new CarouselItem(3),
                new CarouselItem(4)
            };

            GetStartedCommand = new Command(OnGetStarted);
        }

        private async void OnGetStarted()
        {
            // Перехід на сторінку SignIn
            await Shell.Current.GoToAsync("//SignIn");

            //await Application.Current.MainPage.Navigation.PushAsync(new SignInPage());
        }
            
        }
    }
}