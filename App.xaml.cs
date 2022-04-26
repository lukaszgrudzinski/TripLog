using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		DependencyService.Register<INavigationService, XamarinFormsNavigationService>();

		Page mainPage = new NavigationPage(new MainPage());

        var navigationService = (XamarinFormsNavigationService)DependencyService.Get<INavigationService>();

		navigationService.XamarinFormsNav = mainPage.Navigation;

		navigationService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
		navigationService.RegisterViewMapping(typeof(DetailsViewModel), typeof(DetailsPage));
		navigationService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));

		MainPage = mainPage;
	}
}
