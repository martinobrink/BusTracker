using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BusTracker.Models;

namespace BusTracker.Controllers
{
    public class VehicleController : ApiController
    {
      public IEnumerable<Vehicle> Get()
      {
        return MemoryDb.Vehicles;
      }

      public IHttpActionResult Put([FromBody] Vehicle vehicle)
      {
        if (!ModelState.IsValid)
        {
          return BadRequest();
        }

        if (!String.IsNullOrEmpty(vehicle.Id))
        {
          var vehicleToUpdate = MemoryDb.Vehicles.Single(x => x.Id == vehicle.Id);
          vehicleToUpdate.Name = vehicle.Name;
          vehicleToUpdate.Description = vehicle.Description;
          return Ok(vehicleToUpdate);
        }

        var vehicleToCreate = new Vehicle
          {
            Id = Guid.NewGuid().ToString(),
            Name = vehicle.Name,
            Description = vehicle.Description
          };
        MemoryDb.Vehicles.Add(vehicleToCreate);
        return Ok(vehicleToCreate);
      }

      public IHttpActionResult DeleteAll()
      {
        MemoryDb.Vehicles.Clear();
        return Ok();
      }
    }
}
