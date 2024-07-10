using MvvmHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ZXing.Net.Maui.Controls;

namespace FlatFleet.ViewModels
{
    public class QRScannerPageViewModel : BaseViewModel
    {
        public QRScannerPageViewModel()
        {
            BarCodeDetectedCommand = new Command<ZXing.Net.Maui.BarcodeDetectionEventArgs>(barCodeDetected);
        }

        public delegate Task DisplayAlertDelegate(string title, string message, string cancel);
        public DisplayAlertDelegate DisplayAlertCallback { get; set; }
        public ICommand BarCodeDetectedCommand { get; }

        public async void barCodeDetected(ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var code = e.Results?.FirstOrDefault();
            if (code is null)
            {
                return;
            }

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                if (DisplayAlertCallback != null)
                {
                    // Реалізація після успішного сканування QR коду
                    await DisplayAlertCallback("Barcode Detected", code.Value, "OK");
                }
            });
        }
    }
}
