using BlazorBattles.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Pages
{
   [Authorize]
   public partial class Army
   {
      [Inject]
      public IUnitService UnitServise { get; set; }

      protected override async Task OnInitializedAsync()
      {
         await UnitServise.LoadUnitsAsync();
         await UnitServise.LoadUserUnitsAsync();
      }

      private async Task ReviveArmy()
      {
         await UnitServise.ReviveArmy();
      }
   }
}
