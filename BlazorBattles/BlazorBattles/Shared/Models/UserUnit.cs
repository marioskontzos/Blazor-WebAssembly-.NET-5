using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared.Models
{
   public class UserUnit
   {
      public int Id { get; set; }
      public int UserId { get; set; }
      public int UnitId { get; set; }
      public int HitPoints { get; set; }
      public Unit Unit { get; set; }
   }
}
