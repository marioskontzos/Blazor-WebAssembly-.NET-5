using BlazorBattles.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Pages
{
   public partial class BattleLog
   {
      [Inject]
      public IBattleService BattleService { get; set; }

      private string GetClass(string round)
      {
         if (round.Contains("kills"))
            return "list-group-item list-group-item-danger";
         else
            return "list-group-item";
      }
   }
}
