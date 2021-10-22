using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SalesReportViewModel
    { 
        public List<SaleReportItem> SaleReportItems { get; set; }
        public List<Sale> Sales { get; set; }
        public User User { get; set; }
        public DateTime SalesDate { get; set; }
        public List<System.Web.Mvc.SelectListItem> Users { get; set; }
        public SalesReportViewModel()
        {
            Users = new List<System.Web.Mvc.SelectListItem>();
            Sales = new List<Sale>();
            User = new User();
            SalesDate = DateTime.Now;
            SaleReportItems = new List<SaleReportItem>();
            
        }
    }
}