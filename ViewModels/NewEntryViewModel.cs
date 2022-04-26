﻿using System.Device.Location;
using System.Windows.Input;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseValidationViewModel
    {
        private string _title = string.Empty;
        public string Title
        {
            get => _title; 
            set
            {
                _title = value;

                Validate(() => string.IsNullOrWhiteSpace(_title), "Title must be provided");

                OnPropertyChanged();

                _saveCommand?.ChangeCanExecute();
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

                Validate(() => _rating >= 1 && _rating <= 5, "Rating must be between 1 and 5");

                _saveCommand?.ChangeCanExecute();

                OnPropertyChanged();
            }
        }
        private string _notes = string.Empty;
        public string Notes
        {
            get => _notes; 
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        private Command? _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new Command(Save, CanSave);

        private bool CanSave(object arg)
        {
            return !string.IsNullOrWhiteSpace(Title) && !HasErrors;
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

        public NewEntryViewModel(INavigationService navigationService) : base(navigationService)
        {
            Date = DateTime.Today;
            Rating = 1;
        }
    }
}
