using System;
using System.Collections.Generic;
using System.Linq;
using BusTracker.Models;
using Microsoft.AspNet.Mvc;

namespace BusTracker.Controllers
{
    [Route("api/[controller]")]
    public class TrackingController : Controller
    {
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
            return new HttpStatusCodeResult(204);
        }

        [HttpDelete]
        public IActionResult DeleteAllTrackings()
        {
            MemoryDb.Trackings.Clear();
            return new HttpStatusCodeResult(204);
        }
    }
}
