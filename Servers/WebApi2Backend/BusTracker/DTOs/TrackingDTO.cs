using System;
using BusTracker.Models;

namespace BusTracker.DTOs
{
  public class TrackingDTO
  {
    public Vehicle VehicleData { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int HeadingDegrees { get; set; }
    public DateTime Timestamp { get; set; }
  }
}