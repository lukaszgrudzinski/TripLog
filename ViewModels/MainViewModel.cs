using System.Collections.ObjectModel;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TripLogEntry> _logEntries;

        public ObservableCollection<TripLogEntry> LogEntries
        {
            get => _logEntries;
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            LogEntries = new ObservableCollection<TripLogEntry>()
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

        }
    }
}
