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
                    HeadingDegrees = 22,
                    Latitude = 12.87463,
                    Longitude = 11.98236,
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