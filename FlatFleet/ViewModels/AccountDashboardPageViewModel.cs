using FlatFleet.Features.Services;
using FlatFleet.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFleet.ViewModels
{
    public class AccountDashboardPageViewModel
    {
        private readonly CurrentUserStore _userStore;
        private readonly DbService _db;

        public AccountDashboardPageViewModel(CurrentUserStore userStore, DbService db)
        {
            _userStore = userStore;
            _db = db;
        }

        public string UserName => _userStore.CurrentUser.Info.DisplayName;
        public string UserEmail => _userStore.CurrentUser.Info.Email;
        public string UserPhone => null;
        public string UserAccountType => null;

    }
}
