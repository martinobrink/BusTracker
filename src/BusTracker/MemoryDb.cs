using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BusTracker.Models;

namespace BusTracker
{
    public static class MemoryDb
    {
        public static readonly Dictionary<string, Tracking> Trackings = new Dictionary<string, Tracking>(){
            {
                "123456", new Tracking
                {
                    VehicleId = "123456",
                    Heading = "240 degrees",
                    Latitude = "12.983749857",
                    Longitude = "11.42136574561",
                    Timestamp = DateTime.UtcNow
                }
            }
        };

        public static readonly List<Vehicle> Vehicles = new List<Vehicle>(){
            new Vehicle
            {
                Id = "123456",
                Name = "4A",
                Description = "Sejeste bus i verden..."
            }
        };

    }
}