using BlazorBattles.Client.Services;
using BlazorBattles.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Pages
{
   public partial class History
   {
      [Inject]
      public IBattleService BattleService { get; set; }

      protected override async void OnInitialized()
      {
         await BattleService.GetHistory();
      }

      string GetHistoryStyle(BattleHistoryEntry entry)
      {
         if (entry.YouWon)
            return "color: green; font-weight: 600;";
         else
            return string.Empty;
      }
   }
}
