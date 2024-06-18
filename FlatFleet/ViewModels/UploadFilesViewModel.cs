using System;
using System.Collections.Generic;
using System.Windows.Input;
using Camera.MAUI;
using Firebase.Storage;
using FlatFleet.Pages;
using Microsoft.Maui.Controls;

namespace FlatFleet.ViewModels
{
    public class UploadFilesViewModel : ViewModelBase
    {
        private bool _isCameraStarted = false;

        private FirebaseStorage _storage;
        public ICommand CameraOnCommand { get; }
        public ICommand CameraOffCommand { get; }
        public ICommand SaveFilePic { get; }
        public ICommand UploadFileCommand {  get; }

        public event EventHandler<List<FileItem>>? FilesLoaded;
        
        public UploadFilesViewModel(FirebaseStorage storage)
        {
            LoadFiles();
            _storage = storage;
            UploadFileCommand = new Command(Upload);
            CameraOnCommand = new Command(CameraOnFunc);
            CameraOffCommand = new Command(CameraOffFunc);
            SaveFilePic = new Command(SaveVoid);
        }
        public async void SaveVoid()
        {

            // Отримати зображення як ImageSource
            ImageSource imageSource = (Application.Current.MainPage as UploadFilesPage).cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);

            // Перетворити ImageSource у байти
            byte[] imageBytes = await ConvertImageSourceToBytes(imageSource);

            // Шлях до папки, де буде збережено зображення (змініть на ваш варіант)
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Images");

            // Переконайтеся, що папка існує
            Directory.CreateDirectory(folderPath);

            // Генерувати унікальне ім'я файлу
            string fileName = $"snapshot_{DateTime.Now:yyyyMMddHHmmss}.png";
            string filePath = Path.Combine(folderPath, fileName);

            // Записати байти зображення у файл
            File.WriteAllBytes(filePath, imageBytes);
            double imageSizeInKB = imageBytes.Length / 1024.0;

            // Оповістити користувача про успішне збереження (опціонально)
            Console.WriteLine($"Зображення збережено за шляхом: {filePath}");
            Console.WriteLine($"Розмір зображення: {imageSizeInKB:F2} KB");
            (Application.Current.MainPage as UploadFilesPage).lblImageSize.Text = $"Розмір зображення: {imageSizeInKB:F2} KB";
        }
        private async Task<byte[]> ConvertImageSourceToBytes(ImageSource imageSource)
        {
            if (imageSource is FileImageSource fileImageSource && fileImageSource.File.StartsWith("file:", StringComparison.Ordinal))
            {
                var fileBytes = await File.ReadAllBytesAsync(fileImageSource.File.Substring(5));
                return fileBytes;
            }
            else if (imageSource is StreamImageSource streamImageSource)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var stream = await streamImageSource.Stream(CancellationToken.None);
                    await stream.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
            else if (imageSource is UriImageSource uriImageSource)
            {
                using (var client = new HttpClient())
                {
                    var stream = await client.GetStreamAsync(uriImageSource.Uri);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await stream.CopyToAsync(ms);
                        return ms.ToArray();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Unsupported ImageSource type.");
            }
        }


        private void cameraView_CamerasLoaded(object sender, EventArgs e)
        {
            (Application.Current.MainPage as UploadFilesPage).cameraView.Camera = (Application.Current.MainPage as UploadFilesPage).cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (!_isCameraStarted)
                {
                    await (Application.Current.MainPage as UploadFilesPage).cameraView.StartCameraAsync();
                    _isCameraStarted = true;
                }
            });
        }

        private async void CameraOnFunc()
        {
            var page = Application.Current.MainPage as UploadFilesPage;
            if (page != null && page.cameraView != null && page.FrameName != null)
            {
                await Task.Delay(100); // Optional delay to ensure elements are fully initialized

                page.cameraView.IsVisible = true;
                page.FrameName.IsVisible = true;
                if (!_isCameraStarted)
                {
                    await page.cameraView.StartCameraAsync();
                    _isCameraStarted = true;
                }
            }
            else
            {
                Console.WriteLine("Error: cameraView or FrameName is not initialized.");
            }
        }

        private async void CameraOffFunc()
        {
            if (_isCameraStarted)
            {
                await (Application.Current.MainPage as UploadFilesPage).cameraView.StopCameraAsync();
                _isCameraStarted = false;
            }
            (Application.Current.MainPage as UploadFilesPage).cameraView.IsVisible = false;
            (Application.Current.MainPage as UploadFilesPage).FrameName.IsVisible = false;
        }
        private async void Upload()
        {
            LoadFiles();
        }
        private async void LoadFiles()
        {
            var files = await FilePicker.PickAsync();
            var filesToUpload = await files.OpenReadAsync();
            var FilesToUploadList = new List<FileItem>()
            {
                new FileItem { Title = files.FileName, Size = filesToUpload.Length.ToString() },
            };
            // Console.WriteLine(filesToUpload);

            FilesLoaded?.Invoke(this, FilesToUploadList);

            await _storage
                .Child("documents/" + files.FileName)
                .PutAsync(filesToUpload);
        }   
       
    }

    public class FileItem
    {
        public string? Title { get; set; }
        public string? Size { get; set; }
    }
}
