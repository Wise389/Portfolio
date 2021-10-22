using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class AddVehicleViewModel 
    {
        public List<System.Web.Mvc.SelectListItem> Makes { get; set; }

        public List<System.Web.Mvc.SelectListItem> Models { get; set; }
        
        public Vehicle Vehicle { get; set; }

        
    }
}