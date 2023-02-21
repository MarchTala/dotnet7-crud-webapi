using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FormulaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FormulaApi.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class DriversController : ControllerBase
   {
      private static List<Driver> _drivers = new List<Driver>()
      {
         new Driver() {
            Id = 1,
            Name = "Lewis Hamilton",
            Team = "Mercendes AMG F1",
            DriverNumber = 64
         },
         new Driver() {
            Id = 2,
            Name = "George Russel",
            Team = "Mercendes AMG F1",
            DriverNumber = 63
         },
         new Driver() {
            Id = 3,
            Name = "Sebastian Vettel",
            Team = "Austin Martin",
            DriverNumber = 5
         },
      };

      [HttpGet]
      public IActionResult Get()
      {
         return Ok(_drivers);
      }

      [HttpGet]
      [Route("GetById")]
      public IActionResult Get(int id)
      {
         return Ok(_drivers.FirstOrDefault(x => x.Id == id));
      }

      [HttpPost]
      [Route("AddDriver")]
      public IActionResult AddDriver(Driver driver)
      {
         _drivers.Add(driver);
         return Ok();
      }

      [HttpDelete]
      [Route("DeleteDriver")]
      public IActionResult DeleteDriver(int id)
      {
         var driver = _drivers.FirstOrDefault(x => x.Id == id);

         if (driver == null) return NotFound();

         _drivers.Remove(driver);
         return NoContent();
      }

      [HttpPatch]
      [Route("UpdateDriver")]
      public IActionResult UpdateDriver(Driver driver)
      {
			var existDriver = _drivers.FirstOrDefault(x => x.Id == driver.Id);

			if(existDriver == null) return NotFound();

			existDriver.Name = driver.Name;
			existDriver.Team = driver.Team;
			existDriver.DriverNumber = driver.DriverNumber;
		
			return NoContent();
      }
   }
}