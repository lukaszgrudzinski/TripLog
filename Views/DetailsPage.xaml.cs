using TripLog.Models;
using TripLog.ViewModels;

namespace TripLog;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(TripLogEntry entry)
	{
		InitializeComponent();

		BindingContext = new DetailsViewModel(entry);
	}
}