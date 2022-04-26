using TripLog.Models;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class DetailsViewModel : BaseViewModel<TripLogEntry>
    {
        private TripLogEntry _entry = new();
        public TripLogEntry Entry
        {
            get => _entry;
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

        public DetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        public override void Init(TripLogEntry? entry)
        {
            Entry = entry ?? throw new ArgumentNullException(nameof(entry));
        }
    }
}
