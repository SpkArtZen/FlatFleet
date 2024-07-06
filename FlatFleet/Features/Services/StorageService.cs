using Firebase.Storage;
using FlatFleet.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFleet.Features.Services
{
    public class StorageService
    {
        private readonly FirebaseStorage _storage;
        private readonly CurrentUserStore _userStore;

        public StorageService(FirebaseStorage storage, CurrentUserStore userStore) 
        { 
            _storage = storage;
            _userStore = userStore;
        }

        public async Task LoadFilesToStorage(IEnumerable<FileResult> files)
        {
            foreach (var file in files)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    await _storage
                        .Child($"documents/{_userStore.CurrentUser.Uid}/{file.FileName}")
                        .PutAsync(stream);

                    await Application.Current.MainPage.DisplayAlert("Success", "Files were successfully loaded!", "Ok");
                }
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
