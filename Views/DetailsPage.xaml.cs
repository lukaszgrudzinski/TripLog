using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog;

public partial class DetailsPage : ContentPage
{
	public DetailsPage()
	{
		InitializeComponent();

		BindingContext = new DetailsViewModel(DependencyService.Get<INavigationService>());
	}
}