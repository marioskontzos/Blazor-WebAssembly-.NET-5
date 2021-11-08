﻿using BlazorBattles.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
   public interface IBattleService
   {
      public  BattleResult LastBattle { get; set; }
      public IList<BattleHistoryEntry> History { get; set; }
      Task<BattleResult> StartBattle(int opponentId);
      public Task GetHistory();
   }
}
