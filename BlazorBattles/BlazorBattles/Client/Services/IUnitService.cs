using BlazorBattles.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
   public interface IUnitService
   {
      public IList<Unit> Units { get; set; }
      public IList<UserUnit> MyUnits { get; set; }
      public void AddUnit(int unitId);
      Task LoadUnitsAsync();
   }
}
