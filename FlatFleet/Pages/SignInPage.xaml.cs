using Firebase.Auth.Providers;
using Firebase.Auth;
using FlatFleet.ViewModels;

namespace FlatFleet
{
    public partial class SingInPage : ContentPage
    {
        public SingInPage()
        {
            InitializeComponent();
            BindingContext = new SignInViewModel(new Firebase.Auth.FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBGFWSnUtDTw0z508FPy5f_z8Z2aFeTw04",
                AuthDomain = "flat-fleet.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));
        }
    }
}

