using System;
using System.Collections.Generic;
using System.Web.Http;
using BusTracker.Models;
using Microsoft.AspNet.SignalR;

namespace BusTracker.Controllers
{
    public class TrackingController : ApiController
    {
      public IEnumerable<Tracking> Get()
      {
        return MemoryDb.Trackings.Values;
      }

      public IHttpActionResult Put([FromBody] Tracking item)
      {
        if (!ModelState.IsValid)
        {
          return BadRequest();
        }

        item.Timestamp = DateTime.UtcNow;
        MemoryDb.Trackings[item.VehicleId] = item;

        BroadcastTrackingUpdateToAllClients();

        return Ok();
      }

      public IHttpActionResult DeleteAllTrackings()
      {
        MemoryDb.Trackings.Clear();

        BroadcastTrackingUpdateToAllClients();

        return Ok();
      }

      private void BroadcastTrackingUpdateToAllClients()
      {
        var hubContext = GlobalHost.ConnectionManager.GetHubContext<TrackingHub>();
        hubContext.Clients.All.UpdateTrackings(MemoryDb.GetTrackingDTOs());
      }
    }
}
