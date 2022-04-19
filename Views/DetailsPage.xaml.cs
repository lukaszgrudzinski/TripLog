using TripLog.Models;

namespace TripLog;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(TripLogEntry entry)
	{
		InitializeComponent();

		title.Text = entry.Title;
		date.Text = entry.Date.ToString("M");
		rating.Text = $"{entry.Rating} star rating";
		notes.Text = entry.Notes;
	}
}