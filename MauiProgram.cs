using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.Services.AddTransient<ILocationService, LocationService>()
			.AddSingleton<INavigationService, XamarinFormsNavigationService>()
			.AddTransient<MainPage>()
			.AddTransient<DetailsPage>()
			.AddTransient<NewEntryPage>()
			.AddTransient<MainViewModel>()
			.AddTransient<DetailsViewModel>()
			.AddTransient<NewEntryViewModel>();

		return builder.Build();
	}
}
