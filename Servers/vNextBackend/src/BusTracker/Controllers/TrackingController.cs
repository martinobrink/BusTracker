using System;
using System.Collections.Generic;
using System.Linq;
using BusTracker.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.SignalR.Infrastructure;
using Newtonsoft.Json;

namespace BusTracker.Controllers
{
    [Route("api/[controller]")]
    public class TrackingController : Controller
    {
        private readonly IConnectionManager _connectionManager;

        public TrackingController(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        [HttpGet]
        public IEnumerable<Tracking> GetAllTrackings()
        {
            return MemoryDb.Trackings.Values;
        }

        [HttpPut]
        public IActionResult CreateTracking([FromBody] Tracking item)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }

            item.Timestamp = DateTime.UtcNow;
            MemoryDb.Trackings[item.VehicleId] = item;

            BroadcastTrackingUpdateToAllClients();

            return new HttpStatusCodeResult(200);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTracking(string id)
        {
            if (!MemoryDb.Trackings.ContainsKey(id))
            {
                return HttpNotFound();
            }

            MemoryDb.Trackings.Remove(id);

            BroadcastTrackingUpdateToAllClients();

            return new HttpStatusCodeResult(204);
        }

        [HttpDelete]
        public IActionResult DeleteAllTrackings()
        {
            MemoryDb.Trackings.Clear();

            BroadcastTrackingUpdateToAllClients();

            return new HttpStatusCodeResult(204);
        }

        private void BroadcastTrackingUpdateToAllClients()
        {
            var hubContext = _connectionManager.GetHubContext<TrackingHub>();
            hubContext.Clients.All.UpdateTrackings(MemoryDb.GetTrackingDTOs());
        }
    }
}
