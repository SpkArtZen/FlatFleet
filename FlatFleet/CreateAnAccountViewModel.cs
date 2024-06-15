﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Navigation;

namespace FlatFleet
{
    public class CreateAnAccountViewModel : BindableObject
    {
        public ICommand OnTermsOfServiceCommand { get; }
        public ICommand OnPrivacePolicyCommand { get; }
        public CreateAnAccountViewModel()
        {
            OnTermsOfServiceCommand = new Command(OnTermsOfService);
            OnPrivacePolicyCommand = new Command(OnPrivacePolicy);
        }
        private async void OnTermsOfService()
        {
            await NavigationService.NavigateTo(typeof(TermsOfServicePage));
        }

        private async void OnPrivacePolicy()
        {
            await NavigationService.NavigateTo(typeof(PrivacyPolicyPage));
        }
    }
}
