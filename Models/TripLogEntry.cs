using System.Device.Location;

namespace TripLog.Models
{
    public  class TripLogEntry
    {
        public string Title { get; set; }
        public GeoCoordinate GeoCoordinate { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }
}
