using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaApi.Models;

namespace FormulaApi.Core
{
   public interface IDriverRepository : IGenericRepository<Driver>
   {
      Task<Driver?> GetByDriverNumber(int driverNumber);
   }
}