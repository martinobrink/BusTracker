using System.Collections.Generic;
using System.Linq;
using BusTracker.Models;
using Microsoft.AspNet.Mvc;

namespace BusTracker.Controllers
{
    [Route("api/[controller]")]
    public class TrackingController : Controller
    {
        static readonly List<Tracking> _trackings = new List<Tracking>()
        {
            new Tracking
            {
                VehicleId = "123456", 
                Heading = "240 degrees",
                Latitude = "12.983749857",
                Longitude = "11.42136574561"
            }
        };

        [HttpGet]
        public IEnumerable<Tracking> GetAllTrackings()
        {
            return _trackings;
        }

        [HttpPut]
        public IActionResult CreateTracking([FromBody] Tracking item)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }

            _trackings.Add(item);
            return new HttpStatusCodeResult(200);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTracking(string id)
        {
            var item = _trackings.FirstOrDefault(x => x.VehicleId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            _trackings.Remove(item);
            return new HttpStatusCodeResult(204); // 201 No Content
        }

        [HttpDelete]
        public IActionResult DeleteAllTrackings()
        {
            _trackings.Clear();
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}
