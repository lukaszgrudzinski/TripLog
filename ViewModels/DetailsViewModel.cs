using TripLog.Models;

namespace TripLog.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get => _entry;
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

        public DetailsViewModel(TripLogEntry entry)
        {
            Entry = entry;
        }
    }
}
