using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog;

public partial class App : Application
{
	public static IServiceProvider ServiceProvider { get; set; }

	public App(IServiceProvider serviceProvider)
	{
		ServiceProvider = serviceProvider;

		InitializeComponent();

		var navigationService = (new XamarinFormsNavigationService());

		Page mainPage = new NavigationPage(new MainPage(new MainViewModel(navigationService)));

		navigationService.XamarinFormsNav = mainPage.Navigation;

		navigationService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
		navigationService.RegisterViewMapping(typeof(DetailsViewModel), typeof(DetailsPage));
		navigationService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));

		MainPage = mainPage;
	}
}
