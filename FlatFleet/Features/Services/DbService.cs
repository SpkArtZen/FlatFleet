using FlatFleet.Models.Users;
using Google.Cloud.Firestore;
namespace FlatFleet.Features.Services
{
    public class DbService
    {
        private FirestoreDb _db;
        private CurrentUserStore _userStore;

        public DbService(FirestoreDb db, CurrentUserStore userStore)
        {
            _db = db;
            _userStore = userStore;
        }

        public async Task SaveUserToDb(string fullName, string email, string phoneNumber)
        {
            try
            {
                await _db.Collection("users")
                            .Document(_userStore.CurrentUser.Uid)
                            .SetAsync(new
                            {
                                fullName = fullName,
                                email = email,
                                phoneNumber = phoneNumber,
                                accountType = "undefined",
                                documents = Array.Empty<string>()
                            });
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Cannot add user to database: {ex.Message}", "Ok");
            }
        }

        public async Task ChangeUsersAccountType(string accountType)
        {
            await _db.Collection("users")
                .Document(_userStore.CurrentUser.Uid)
                .SetAsync(new
                {
                    accountType = accountType
                });
        }
    }
}
