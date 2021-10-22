using CarDealership.Models;
using CarDealership.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class PurchaseViewModel
    {
        public List<System.Web.Mvc.SelectListItem> States { get; set; }

        public List<System.Web.Mvc.SelectListItem> PurchaseType { get; set; }
        public Sale Sale { get; set; }
        public Vehicle Vehicle { get; set; }
        public PurchaseViewModel()
        {
            States = new List<System.Web.Mvc.SelectListItem>();
            PurchaseType = new List<System.Web.Mvc.SelectListItem>();
            Sale = new Sale();
            Vehicle = new Vehicle();

        }
    }
}