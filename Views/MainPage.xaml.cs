using TripLog.Models;

namespace TripLog;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		var items = new List<TripLogEntry>()
		{
			new TripLogEntry()
			{
				Title = "Washington Monument",
				Notes = "Amazing!",
				Rating = 3,
				Date = new DateTime(2019, 2, 5),
				GeoCoordinate = new System.Device.Location.GeoCoordinate(38, -77)
			},
			new TripLogEntry()
			{
				Title = "Washington Monument2",
				Notes = "Amazing!",
				Rating = 3,
				Date = new DateTime(2019, 2, 5),
				GeoCoordinate = new System.Device.Location.GeoCoordinate(38, -77)
			},
			new TripLogEntry()
			{
				Title = "Washington Monument3",
				Notes = "Amazing!",
				Rating = 3,
				Date = new DateTime(2019, 2, 5),
				GeoCoordinate = new System.Device.Location.GeoCoordinate(38, -77)
			}
		};

		trips.ItemsSource = items;
	}

	private void New_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new NewEntryPage());
    }
}