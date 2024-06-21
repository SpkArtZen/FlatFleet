using CommunityToolkit.Maui.Core;
using FlatFleet.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class PopupScreenViewModel : ViewModelBase
    {
        private double _screenWidth;
        public double ScreenWidth
        {
            get => _screenWidth;
            set
            {
                if (_screenWidth != value)
                {
                    _screenWidth = value;
                    OnPropertyChanged(nameof(ScreenWidth));
                }
            }
        }

        private double _screenHeight;
        public double ScreenHeight
        {
            get => _screenHeight;
            set
            {
                if (_screenHeight != value)
                {
                    _screenHeight = value;
                    OnPropertyChanged(nameof(ScreenHeight));
                }
            }
        }

        // Margin between centered items and the bottom of the screen idk
        private Thickness _margin;
        public Thickness Margin
        {
            get => _margin;
            set
            {
                if (_margin != value)
                {
                    _margin = value;
                    OnPropertyChanged(nameof(Margin));
                }
            }
        }

        public PopupScreenViewModel()
        {
            ScreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density;
            ScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.Current.MainDisplayInfo.Density;

            Margin = new Thickness(0, 0, 0, 48 / DeviceDisplay.Current.MainDisplayInfo.Density);

            Debug.WriteLine($"SW (PX): {ScreenWidth}", "Popup");
            Debug.WriteLine($"SH (PX): {ScreenHeight}", "Popup");

        }
    }
}
