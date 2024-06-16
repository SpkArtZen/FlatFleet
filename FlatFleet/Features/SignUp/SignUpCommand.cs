using Firebase.Auth;

namespace FlatFleet.Features.SignUp
{
    public partial class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpPageViewModel _viewModel;
        private readonly FirebaseAuthClient _authClient;

        public SignUpCommand(SignUpPageViewModel viewModel, FirebaseAuthClient authClient)
        {
            _viewModel = viewModel;
            _authClient = authClient;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password, _viewModel.FullName);
                await Application.Current.MainPage.DisplayAlert("Success", "Successfully signed up!", "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign up. Please try again later.", "Ok");
            }
        }
    }
}
