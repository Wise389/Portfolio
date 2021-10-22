using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class HomePageViewModel
    {
        public List<Vehicle> Featured { get; set; }
        public List<Special> Specials { get; set; }

        public HomePageViewModel()
        {
            Featured = new List<Vehicle>();
            Specials = new List<Special>();
        }
    }
}