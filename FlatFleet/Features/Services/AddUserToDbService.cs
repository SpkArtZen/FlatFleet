using FlatFleet.Models.Users;
using Google.Cloud.Firestore;
namespace FlatFleet.Features.Services
{
    public class AddUserToDbService
    {
        private SignUpPageViewModel _viewModel;
        private FirestoreDb _db;
        private CurrentUserStore _userStore;

        public AddUserToDbService(SignUpPageViewModel viewModel, FirestoreDb db, CurrentUserStore userStore)
        {
            _viewModel = viewModel;
            _db = db;
            _userStore = userStore;
        }

        public async Task SaveUserToDb()
        {
            await _db.Collection("users")
                        .Document(_userStore.CurrentUser.Uid)
                        .SetAsync(new
                        {
                            fullName = _viewModel.FullName,
                            email = _viewModel.Email,
                            phoneNumber = _viewModel.PhoneNumber,
                            accountType = "undefined",
                            documents = Array.Empty<string>()
                        });
        }
    }
}
