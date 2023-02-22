using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Data
{
   public class ApiDbContext : DbContext
   {
      public DbSet<Driver>? Drivers { get; set; }

      public ApiDbContext(DbContextOptions options) : base(options)
      {

      }
   }
}