using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BusTracker.Models;

namespace BusTracker
{
    public static class MemoryDb
    {
        public static readonly Dictionary<string, Tracking> Trackings = new Dictionary<string, Tracking>();
        public static readonly List<Vehicle> Vehicles = new List<Vehicle>();
    }
}