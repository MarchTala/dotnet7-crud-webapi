using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Core.Repositories
{
   public class DriverRepository : GenericRepository<Driver>, IDriverRepository
   {
      public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
      {
      }

      public override async Task<IEnumerable<Driver>> All()
      {
         try
         {
            var driver = _context.Drivers;
            if (driver != null)
            {
               return await driver.Where(x => x.Id < 100).ToListAsync();
            }
            else
            {
               return Enumerable.Empty<Driver>();
            }
         }
         catch (System.Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      public override async Task<Driver?> GetById(int id)
      {
         try
         {
            var driver = _context.Drivers;
            if (driver != null)
            {
               return await driver.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
               return null;
            }
         }
         catch (System.Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      public async Task<Driver?> GetByDriverNumber(int driverNumber)
      {
         try
         {
            var driver = _context.Drivers;
            if (driver != null)
            {
               return await driver.FirstOrDefaultAsync(x => x.DriverNumber == driverNumber);
            }
            else
            {
               return null;
            }
         }
         catch (System.Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }
   }
}