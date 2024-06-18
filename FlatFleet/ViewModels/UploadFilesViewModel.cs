using System;
using System.Collections.Generic;
using System.Windows.Input;
using FlatFleet.Pages;
using Microsoft.Maui.Controls;

namespace FlatFleet.ViewModels
{
    public class UploadFilesViewModel : BindableObject
    {
        public ICommand UploadFileCommand {  get; }

        public event EventHandler<List<FileItem>>? FilesLoaded;
        public UploadFilesViewModel()
        {
            LoadFiles();
            UploadFileCommand = new Command(Upload);
        }
        private async void Upload()
        {
            LoadFiles();
        }
        private void LoadFiles()
        {
            var files = GetFilesFromSystem();
            FilesLoaded?.Invoke(this, files);
        }

        private List<FileItem> GetFilesFromSystem()
        {
            return new List<FileItem>
            {
                new FileItem { Title = "Document title 1", Size = "1.0 KB" },
                new FileItem { Title = "Document title 2", Size = "2.0 KB" }
            };
        }
    }

    public class FileItem
    {
        public string? Title { get; set; }
        public string? Size { get; set; }
    }
}
