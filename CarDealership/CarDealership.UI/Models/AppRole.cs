using CarDealership.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class AppRole : IdentityRole
    {
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}