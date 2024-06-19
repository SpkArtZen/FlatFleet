using Firebase.Auth;
using FlatFleet.Models.Users;
using FlatFleet.ViewModels;

namespace FlatFleet.Features.SignIn
{
    public class SignInCommand : AsyncCommandBase
    {
        private readonly SignInPageViewModel _viewModel;
        private readonly FirebaseAuthClient _authClient;
        private CurrentUserStore _userStore;

        public SignInCommand(SignInPageViewModel viewModel, FirebaseAuthClient authClient, CurrentUserStore userStore)
        {
            _viewModel = viewModel;
            _authClient = authClient;
            _userStore = userStore;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var userCredential = await _authClient.SignInWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);
                if (userCredential != null)
                {
                    _userStore.CurrentUser = userCredential.User;
                    await Application.Current.MainPage.DisplayAlert("Success", "Successfully signed in!", "Ok");
                    await Shell.Current.GoToAsync("//SelectAccountType");
                }
            }
            catch (FirebaseAuthException)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Incorrect password or email! Try again!", "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign in. Please try again later.", "Ok");
            }
        }
    }
}
