using System;
using System.ComponentModel.DataAnnotations;

namespace BusTracker.Models
{
    public class Tracking
    {
        [Required]
        public string VehicleId { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
        public string Heading { get; set; }
        public DateTime Timestamp { get; set; }
    }
}