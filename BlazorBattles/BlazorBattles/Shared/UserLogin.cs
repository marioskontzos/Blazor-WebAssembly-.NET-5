﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
   public class UserLogin
   {
      [Required(ErrorMessage = "Please enter a user name.")]
      public string UseName { get; set; }
      [Required(ErrorMessage = "Please enter a password.")]
      public string Password { get; set; }
   }
}
