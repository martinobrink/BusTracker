using System;
using System.Collections.Generic;
using System.Linq;
using BusTracker.Models;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BusTracker.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {

        static readonly List<Vehicle> _vehicles = new List<Vehicle>()
        {
            new Vehicle
            {
                Id = "123456",
                Name = "4A",
                Description = "Sejeste bus i verden..."
            }
        };

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicles;
        }

        [HttpGet("{id}")]
        public Vehicle Get(string id)
        {
            return _vehicles.FirstOrDefault( x => x.Id == id);
        }

        [HttpPut()]
        public IActionResult Put([FromBody]Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }

            if (!String.IsNullOrEmpty(vehicle.Id))
            {
                var vehicleToUpdate = _vehicles.Single(x => x.Id == vehicle.Id);
                vehicleToUpdate.Name = vehicle.Name;
                vehicleToUpdate.Description = vehicle.Description;
                return new JsonResult(vehicleToUpdate);
            }
            else
            {
                var vehicleToCreate = new Vehicle
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = vehicle.Name,
                    Description = vehicle.Description
                };
                _vehicles.Add(vehicleToCreate);
                return new JsonResult(vehicleToCreate);
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public void DeleteAll()
        {
            _vehicles.Clear();
        }
    }
}
