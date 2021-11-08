using BlazorBattles.Client.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Pages
{
   public partial class Leaderboard
   {
      [Inject]
      public ILeaderboardService LeaderboadService { get; set; }

      [Inject]
      public AuthenticationStateProvider AuthStateProvider { get; set; }

      [Inject]
      public IBattleService BattleService { get; set; }

      [Inject]
      public IBananaService BananaService { get; set; }

      [Inject]
      public IToastService ToastService { get; set; }

      [Inject]
      public NavigationManager NavigationManager { get; set; }

      public int MyUserId { get; set; }

      protected override async Task OnInitializedAsync()
      {
         await LeaderboadService.GetLeaderboard();

         var authState = await AuthStateProvider.GetAuthenticationStateAsync();
         MyUserId = int.Parse(authState.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
      }

      public string GetMyStyle(int userId)
      {
         if (userId == MyUserId)
            return "color: green; font-weight: 600;";
         else
            return string.Empty;
      }

      public async Task StartBattle(int opponentId)
      {
         Console.WriteLine($"Start battle with {opponentId}.");
         var result = await BattleService.StartBattle(opponentId);

         if (result.RoundsFought <= 0)
            ToastService.ShowInfo("The battle did not take place.");
         else if (result.IsVictory)
            ToastService.ShowSuccess("You won the battle.");
         else
            ToastService.ShowWarning("You have been destroyed!");

         await LeaderboadService.GetLeaderboard();
         await BananaService.GetBananas();

         if (result.RoundsFought > 0)
            NavigationManager.NavigateTo("battlelog");
      }
   }
}
