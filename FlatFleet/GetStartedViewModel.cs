using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FlatFleet
{
    public class GetStartedViewModel : INotifyPropertyChanged
    {
        private int clickCount = 0;
        private bool isFrame1Visible = true;
        private bool isFrame4Visible = false;
        private Color pointOneColor = Colors.Blue;
        private Color pointFourColor = Colors.LightGray;

        public ICommand GetStartedCommand { get; }

        public bool IsFrame1Visible
        {
            get => isFrame1Visible;
            set
            {
                if (isFrame1Visible != value)
                {
                    isFrame1Visible = value;
                    OnPropertyChanged(nameof(IsFrame1Visible));
                }
            }
        }

        public bool IsFrame4Visible
        {
            get => isFrame4Visible;
            set
            {
                if (isFrame4Visible != value)
                {
                    isFrame4Visible = value;
                    OnPropertyChanged(nameof(IsFrame4Visible));
                }
            }
        }

        public Color PointOneColor
        {
            get => pointOneColor;
            set
            {
                if (pointOneColor != value)
                {
                    pointOneColor = value;
                    OnPropertyChanged(nameof(PointOneColor));
                }
            }
        }

        public Color PointFourColor
        {
            get => pointFourColor;
            set
            {
                if (pointFourColor != value)
                {
                    pointFourColor = value;
                    OnPropertyChanged(nameof(PointFourColor));
                }
            }
        }

        public GetStartedViewModel()
        {
            GetStartedCommand = new Command(OnGetStarted);
        }

        private async void OnGetStarted()
        {
            clickCount++;

            if (clickCount == 1)
            {
                IsFrame1Visible = false;
                IsFrame4Visible = true;
                // Оновлюємо кольори індикаторів
                PointOneColor = Colors.LightGray;
                PointFourColor = Colors.Blue;
            }
            else if (clickCount == 2)
            {
                // Перехід на сторінку SignIn
                await Application.Current.MainPage.Navigation.PushAsync(new SignIn());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
