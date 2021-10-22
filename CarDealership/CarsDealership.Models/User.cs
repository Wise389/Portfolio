using CarDealership.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class User
    { 
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set;}
        public string ConfirmationPassword { get; set; }
        public User()
        {
            FirstName = "Steve";
            LastName = "Buchemi";
            Email = "SBuchemi@email.com";
            Role = Role.Disabled;
            Password = "";
            ConfirmationPassword = "";
        }
    }
}

//finish user
//doublecheck stored proceedures
//wire ui
//styling
//