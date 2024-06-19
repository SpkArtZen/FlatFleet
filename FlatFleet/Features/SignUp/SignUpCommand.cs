using Firebase.Auth;
using FlatFleet.Models.Users;
using Google.Cloud.Firestore;

namespace FlatFleet.Features.SignUp
{
    public partial class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpPageViewModel _viewModel;
        private readonly FirebaseAuthClient _authClient;
        private FirestoreDb _db;
        private CurrentUserStore _userStore;

        public SignUpCommand(SignUpPageViewModel viewModel, FirebaseAuthClient authClient, FirestoreDb db , CurrentUserStore userStore)
        {
            _viewModel = viewModel;
            _authClient = authClient;
            _db = db;
            _userStore = userStore;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var userCredential = await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password, _viewModel.FullName);

                if (userCredential != null)
                {
                    await _db.Collection("users")
                        .AddAsync(new
                        {
                            fullName = _viewModel.FullName,
                            email = _viewModel.Email,
                            phoneNumber = _viewModel.PhoneNumber,
                            accountType = "undefined",
                            documents = Array.Empty<string>()
                        });

                    _userStore.CurrentUser = userCredential.User;
                    await Application.Current.MainPage.DisplayAlert("Success", "Successfully signed up!", "Ok");
                    await Shell.Current.GoToAsync("//SelectAccountType");
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign up. Please try again later.", "Ok");
            }
        }
    }
}
