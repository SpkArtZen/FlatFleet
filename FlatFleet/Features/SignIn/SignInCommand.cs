﻿using CommunityToolkit.Maui.Views;
using Firebase.Auth;
using FlatFleet.Models.Users;
using FlatFleet.ViewModels;
using FlatFleet.Views;
using System.Diagnostics;

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
            var loadingPopup = new LoadingScreenPopUp();

            Application.Current.MainPage.ShowPopupAsync(loadingPopup);
            
            Debug.WriteLine("Popup was opened");

            try
            {
                var userCredential = await _authClient.SignInWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);
                
                await loadingPopup.CloseAsync();

                Debug.WriteLine("Popup was closed");
                
                if (userCredential != null)
                {
                    _userStore.CurrentUser = userCredential.User;
                    await Application.Current.MainPage.DisplayAlert("Success", "Successfully signed in!", "OK");

                    var welcomePopup = new WelcomePopUp();

                    Application.Current.MainPage.ShowPopupAsync(welcomePopup);

                    await Task.Run(() => Thread.Sleep(2000));

                    await welcomePopup.CloseAsync();

                    await Shell.Current.GoToAsync("SelectAccountType");
                }
            }
            catch (FirebaseAuthException)
            {
                await loadingPopup.CloseAsync();

                await Application.Current.MainPage.DisplayAlert("Error", "Incorrect password or email! Try again!", "OK");
            }
            catch (Exception)
            {
                await loadingPopup.CloseAsync();

                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign in. Please try again later.", "OK");
            }
        }
    }
}
