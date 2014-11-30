using System;
using System.Collections.Generic;
using BusTracker.Models;
using BusTracker.DTOs;
using System.Linq;

namespace BusTracker
{
  public static class MemoryDb
  {
    public static readonly Dictionary<string, Tracking> Trackings = new Dictionary<string, Tracking>(){
            {//@Rutebilstationen
                "1", new Tracking
                {
                    VehicleId = "1",
                    HeadingDegrees = 22,
                    Latitude = 56.151927,
                    Longitude = 10.203420,
                    Timestamp = DateTime.UtcNow
                }
            },
            {//@Busgaden
                "2", new Tracking
                {
                    VehicleId = "2",
                    HeadingDegrees = 22,
                    Latitude = 56.154487,
                    Longitude = 10.205178,
                    Timestamp = DateTime.UtcNow
                }
            }
        };

    public static readonly List<Vehicle> Vehicles = new List<Vehicle>(){
            new Vehicle
            {
                Id = "1",
                Name = "1A",
                Description = "Kolt - Trige/Lystrup"
            },
            new Vehicle
            {
                Id = "2",
                Name = "2A",
                Description = "Holme - Skejby Sygehus"
            },
            new Vehicle
            {
                Id = "3",
                Name = "3A",
                Description = "Tilst - Rutebilstationen"
            },
            new Vehicle
            {
                Id = "4",
                Name = "4A",
                Description = "Brabrand Nord - Østerby"
            }
        };

    public static IEnumerable<TrackingDTO> GetTrackingDTOs()
    {
      return Trackings.Values
          .Select(x =>
          new TrackingDTO
          {
            HeadingDegrees = x.HeadingDegrees,
            Latitude = x.Latitude,
            Longitude = x.Longitude,
            Timestamp = x.Timestamp,
            VehicleData = Vehicles.FirstOrDefault(v => v.Id == x.VehicleId)
          });
    }
  }
}