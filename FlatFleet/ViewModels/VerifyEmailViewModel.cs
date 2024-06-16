﻿using FlatFleet.Features.Navigation;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class VerifyEmailViewModel : BindableObject
    {
        public ICommand VerifyCodeOnEmail { get; }
        public VerifyEmailViewModel()
        {
            VerifyCodeOnEmail = new Command(CheckEmailCode);
        }
        private async void CheckEmailCode()
        {
            await NavigationService.NavigateTo(typeof(EntryNewPasswordPage));
        }
    }
}
