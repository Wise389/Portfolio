using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class SaleReportItem
    {
        public decimal TotalSales { get; set; }
        public int VehiclesSold { get; set; }
        public string UserName { get; set; }
        public SaleReportItem()
        {
            TotalSales = 0;
            VehiclesSold = 0;
            UserName = "";
        }
    }
}
