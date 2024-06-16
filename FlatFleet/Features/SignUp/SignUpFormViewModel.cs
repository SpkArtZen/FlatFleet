using Firebase.Auth;
using FlatFleet.ViewModels;
using System.Windows.Input;

namespace FlatFleet.Features.SignUp
{
    public class SignUpFormViewModel : ViewModelBase
    {
		private string _email;

		public string Email
		{
			get { return _email; }
			set 
			{ 
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}

		private string _fullName;

        public string FullName
		{
			get { return _fullName; }
			set 
			{
				_fullName = value; 
				OnPropertyChanged(nameof(FullName));
			}
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set 
			{ 
				_password = value;
                OnPropertyChanged(nameof(Password));
            }
		}

		private string _phoneNumber;

		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set 
			{ 
				_phoneNumber = value;
				OnPropertyChanged(nameof(PhoneNumber));
			}
		}


		public ICommand SignUpCommand { get; }

        public SignUpFormViewModel(FirebaseAuthClient authClient)
        {
            SignUpCommand = new SignUpCommand(this, authClient);
        }
    }
}
