using Firebase.Auth.Providers;
using Firebase.Auth;

namespace FlatFleet;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = new SignUpPageViewModel(new Firebase.Auth.FirebaseAuthClient(new FirebaseAuthConfig()
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