using System.Collections.Generic;
using System.Linq;
using BusTracker.Models;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BusTracker.Controllers
{

    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        static readonly List<Vehicle> _items = new List<Vehicle>()
        {
            new Vehicle
            {
                Id = "123456", 
                Heading = "240 degrees",
                Latitude = "12.983749857",
                Longitude = "11.42136574561"
            }
        };

        [HttpGet]
        public IEnumerable<Vehicle> GetAll()
        {
            return _items;
        }

        [HttpPut]
        public IActionResult CreateVehicle([FromBody] Vehicle item)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }

            _items.Add(item);
            return new HttpStatusCodeResult(200);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteItem(string id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            _items.Remove(item);
            return new HttpStatusCodeResult(204); // 201 No Content
        }

        [HttpDelete]
        public IActionResult DeleteAll()
        {
            _items.Clear();
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}
