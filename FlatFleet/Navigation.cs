using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class NavigationService
    {
        public static async Task Navigate(Type page)
        {
            try
            {
                var Page = (Page)Activator.CreateInstance(page);
                await Application.Current.MainPage.Navigation.PushAsync(Page);
            }
            catch
            {
                throw new ArgumentException("Page not found");
            }
        }
    }
}
