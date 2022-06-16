using TripLog.Models;

namespace TripLog.Services
{
    public interface ILocationService
    {
        Task<Geocords> GetLocationAsync();
    }
}
