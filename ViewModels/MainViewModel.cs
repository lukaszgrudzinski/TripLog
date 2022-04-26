using System.Collections.ObjectModel;
using System.Windows.Input;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command<TripLogEntry> ViewCommand => new(async entry => await NavigationService.NavigateTo<DetailsViewModel, TripLogEntry>(entry));
        public Command NewCommand => new(async () => await NavigationService.NavigateTo<NewEntryViewModel>());

        private ObservableCollection<TripLogEntry> _logEntries = new();

        public ObservableCollection<TripLogEntry> LogEntries
        {
            get => _logEntries;
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void Init()
        {
            LoadEntries();
        }

        private void LoadEntries()
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
