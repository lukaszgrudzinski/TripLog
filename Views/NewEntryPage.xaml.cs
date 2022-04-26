using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog;

public partial class NewEntryPage : ContentPage
{
	public NewEntryPage()
	{
		InitializeComponent();

		BindingContext = new NewEntryViewModel(DependencyService.Get<INavigationService>());
	}
}