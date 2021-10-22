using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ChangePasswordViewModel
    { 
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserId { get; set; }
        public ChangePasswordViewModel()
        {
            Password = "";
            ConfirmPassword = "";
            UserId = "";
        }
    }
}