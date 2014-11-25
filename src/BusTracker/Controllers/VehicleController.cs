using System;
using System.Collections.Generic;
using System.Linq;
using BusTracker.Models;
using Microsoft.AspNet.Mvc;

namespace BusTracker.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return MemoryDb.Vehicles;
        }

        [HttpGet("{id}")]
        public Vehicle Get(string id)
        {
            return MemoryDb.Vehicles.FirstOrDefault( x => x.Id == id);
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
                var vehicleToUpdate = MemoryDb.Vehicles.Single(x => x.Id == vehicle.Id);
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
                MemoryDb.Vehicles.Add(vehicleToCreate);
                return new JsonResult(vehicleToCreate);
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public void DeleteAll()
        {
            MemoryDb.Vehicles.Clear();
        }
    }
}
