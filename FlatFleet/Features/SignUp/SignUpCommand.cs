using Firebase.Auth;

namespace FlatFleet.Features.SignUp
{
    public partial class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpFormViewModel _viewModel;
        private readonly FirebaseAuthClient _authClient;

        public SignUpCommand(SignUpFormViewModel viewModel, FirebaseAuthClient authClient)
        {
            _viewModel = viewModel;
            _authClient = authClient;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);
                // some sort of alert
            }
            catch (Exception ex)
            {
                // another alert
            }
        }
    }
}
