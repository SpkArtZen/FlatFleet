using FlatFleet.ViewModels;
using ZXing.Net.Maui.Controls;
namespace FlatFleet.Pages;

public partial class QRScannerPage : ContentPage
{
    private QRScannerPageViewModel viewModel;

    public QRScannerPage()
    {
        InitializeComponent();

        viewModel = new QRScannerPageViewModel();
        viewModel.DisplayAlertCallback = DisplayAlert;
        BindingContext = viewModel;

        // Attach the event handler for barcode detection
        barcodeReader.BarcodesDetected += BarcodeReader_BarcodesDetected;
    }

    private void BarcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        viewModel.BarCodeDetectedCommand.Execute(e);
    }
}