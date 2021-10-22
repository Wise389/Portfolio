using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Enumerations;

namespace CarDealership.Models
{
    public class Sale
    {
        public int SalesId { get; set; }
        public decimal PurchasePrice { get; set; }
        public SalesType SalesType { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime SalesDate { get; set; }
        public string SalesPerson { get; set; }
        public Sale()
        {
            PurchasePrice = 1000m;
            SalesType = SalesType.Bank_Finance;
            Customer = new Customer();
            Vehicle = new Vehicle();
            SalesDate = DateTime.Now;
            SalesPerson = "";
        }
    }
}
