namespace FlatFleet.Features.Navigation
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
