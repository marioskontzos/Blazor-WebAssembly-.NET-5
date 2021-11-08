using BlazorBattles.Client.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Pages
{
   [Authorize]
   public partial class Build
   {
      [Inject]
      public IToastService ToastService { get; set; }

      [Inject]
      public IBananaService BananaService { get; set; }

      [Inject]
      public IUnitService UnitService { get; set; }

      public int SelectedUnitId { get; set;} = 1;
      public bool NeedMoreBananas { get; set; } = false;

      protected override async Task OnInitializedAsync()
      {
         await UnitService.LoadUnitsAsync();
      }

      public async Task BuildUnit()
      {
         await UnitService.AddUnit(SelectedUnitId);
      }
   }
}
