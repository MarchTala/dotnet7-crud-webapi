using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaApi.Core
{
   public interface IUnitOfWork
   {
      IDriverRepository Drivers { get; set; }
      Task CompleteAsync();
   }
}