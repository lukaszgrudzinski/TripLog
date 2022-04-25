using System.Device.Location;
using System.Windows.Input;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get => _title; 
            set
            {
                _title = value;

                OnPropertyChanged();

                _saveCommand.ChangeCanExecute();
            }
        }
        private double _latitude;
        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }
        private double _longtitude;
        public double Longtitude
        {
            get => _longtitude;
            set
            {
                _longtitude = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date; 
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        private int _rating;
        public int Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }
        private string _notes;
        public string Notes
        {
            get => _notes; 
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        private Command _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new Command(Save, CanSave);

        private bool CanSave(object arg)
        {
            return !string.IsNullOrWhiteSpace(Title);
        }

        private void Save(object obj)
        {
            TripLogEntry newItem = new()
            {
                Title = Title,
                GeoCoordinate = new GeoCoordinate(Latitude, Longtitude),
                Date = Date,
                Rating = Rating,
                Notes = Notes
            };

            //TODO:Persistency
        }

        public NewEntryViewModel()
        {
            Date = DateTime.Today;
            Rating = 1;
        }
    }
}
