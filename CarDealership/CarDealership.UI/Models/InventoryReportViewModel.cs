using CarDealership.Models;
using CarsDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class InventoryReportViewModel
    {
        public List<InventoryReport> NewVehicles { get; set; }
        public List<InventoryReport> UsedVehicles { get; set; }
    }
}