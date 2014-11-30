using System.Collections.Generic;
using BusTracker.DTOs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BusTracker
{
  [HubName("TrackingHub")]
  public class TrackingHub : Hub<ITrackingHub>
  {
  }

  public interface ITrackingHub
  {
    void UpdateTrackings(IEnumerable<TrackingDTO> trackings);
  }
}