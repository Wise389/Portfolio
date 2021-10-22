using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class EditVehicleViewModel
    {
        public List<System.Web.Mvc.SelectListItem> Makes { get; set; }

        public List<System.Web.Mvc.SelectListItem> Models { get; set; }

        public Vehicle Vehicle { get; set; }
        public string Description1 { get; set; }

    }
}