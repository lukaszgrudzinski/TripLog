using TripLog.Models;

namespace TripLog.Services
{
    public class LocationService : ILocationService
    {
        public Task<Geocords> GetLocationAsync()
        {
            return Task.FromResult(new Geocords());
        }
    }
}
