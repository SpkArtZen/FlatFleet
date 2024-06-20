using Firebase.Auth;
using FlatFleet.Features.Services;
using FlatFleet.Models.Users;

namespace FlatFleet.Features.SignUp
{
    public partial class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpPageViewModel _viewModel;
        private readonly FirebaseAuthClient _authClient;
        private readonly DbService _service;
        private CurrentUserStore _userStore;

        public SignUpCommand(SignUpPageViewModel viewModel, FirebaseAuthClient authClient, DbService service , CurrentUserStore userStore)
        {
            _viewModel = viewModel;
            _authClient = authClient;
            _service = service;
            _userStore = userStore;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var userCredential = await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password, _viewModel.FullName);
                _userStore.CurrentUser = userCredential.User;

                await _service.SaveUserToDb(
                    fullName: _viewModel.FullName,
                    email: _viewModel.Email,
                    phoneNumber: _viewModel.PhoneNumber
                    );
                    
                await Application.Current.MainPage.DisplayAlert("Success", "Successfully signed up!", "Ok");
                await Shell.Current.GoToAsync("//SelectAccountType");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign up. Please try again later.", "Ok");
            }
        }
    }
}
