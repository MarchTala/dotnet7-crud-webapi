using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaApi.Models
{
   public class Driver
   {
      public int Id { get; set; }
      public string? Name { get; set; }

      public int DriverNumber { get; set; }

      public string? Team { get; set; }
   }
}