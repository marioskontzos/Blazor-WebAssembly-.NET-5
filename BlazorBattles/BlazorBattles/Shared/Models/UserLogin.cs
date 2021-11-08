using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared.Models
{
   public class UserLogin
   {
      [Required(ErrorMessage = "Please enter an Email Address.")]
      public string Email { get; set; }
      [Required(ErrorMessage = "Please enter a password.")]
      public string Password { get; set; }
   }
}
