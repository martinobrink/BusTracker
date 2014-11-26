using System;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using BusTracker.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace BusTracker
{
    [HubName("TrackingHub")]
    public class TrackingHub : Hub<ITrackingHub>
    {
    }

    public interface ITrackingHub
    {
        void UpdateTrackings(IEnumerable<Tracking> trackings);
    }
}