using BlazorBattles.Client.Services;
using BlazorBattles.Shared.Models;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Pages
{
   public partial class Register
   {
      [Inject]
      public IUnitService UnitService { get; set; }

      [Inject]
      public NavigationManager NavigationManager { get; set; }

      [Inject]
      public IAuthService AuthService { get; set; }

      [Inject]
      public IToastService ToastService { get; set; }


      public UserRegister User = new UserRegister();

      protected override async Task OnInitializedAsync()
      {
         await UnitService.LoadUnitsAsync();
      }

      async void HandleRegistration()
      {
         var result = await AuthService.Register(User);
         if (result.Success)
         {
            ToastService.ShowSuccess(result.Message);
            NavigationManager.NavigateTo("/");
         }
         else
         {
            ToastService.ShowError(result.Message);
         }
      }
   }
}
