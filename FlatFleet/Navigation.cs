using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class NavigationService
    {
        public static async Task NavigateTo(Page page)
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PushAsync(page);
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(page);
            }
        }

        public static async Task NavigateTo(Type pageType)
        {
            var page = (Page)Activator.CreateInstance(pageType);
            await NavigateTo(page);
        }
    }
}
