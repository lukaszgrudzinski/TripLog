using TripLog.Models;
using TripLog.ViewModels;

namespace TripLog;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainViewModel();
	}

    private async void trips_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		TripLogEntry trip = (TripLogEntry)e.CurrentSelection.FirstOrDefault();

		if(trip != null)
        {
			await Navigation.PushAsync(new DetailsPage(trip));
        }

		//Clear selection
		trips.SelectedItem = null;
    }

	private void New_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new NewEntryPage());
	}
}