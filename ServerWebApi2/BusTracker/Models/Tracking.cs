using System;
using System.ComponentModel.DataAnnotations;

namespace BusTracker.Models
{
  public class Tracking
  {
    [Required]
    public string VehicleId { get; set; }
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
    public int HeadingDegrees { get; set; }
    public DateTime Timestamp { get; set; }
  }
}