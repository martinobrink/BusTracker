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
        private static readonly Dictionary<string, Tracking> _trackings = new Dictionary<string, Tracking>
        {
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

        [HttpGet]
        public IEnumerable<Tracking> GetAllTrackings()
        {
            return _trackings.Values;
        }

        [HttpPut]
        public IActionResult CreateTracking([FromBody] Tracking item)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }

            item.Timestamp = DateTime.UtcNow;
            _trackings[item.VehicleId] = item;

            return new HttpStatusCodeResult(200);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTracking(string id)
        {
            if (!_trackings.ContainsKey(id))
            {
                return HttpNotFound();
            }

            _trackings.Remove(id);
            return new HttpStatusCodeResult(204);
        }

        [HttpDelete]
        public IActionResult DeleteAllTrackings()
        {
            _trackings.Clear();
            return new HttpStatusCodeResult(204);
        }
    }
}
