using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SpecialsViewModel
    {
         public List<Special> Specials { get; set; }
         public Special Special { get; set; }
         public SpecialsViewModel()
         {
             Specials = new List<Special>();
             Special = new Special();
         }
    }
}