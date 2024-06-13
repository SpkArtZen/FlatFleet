namespace FlatFleet
{
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
            BindingContext = new SignInViewModel();
        }
    }

    
}

