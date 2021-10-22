using CarDealership.Models;
using CarsDealership.DAL.Interface;
using CarsDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Repository
{
    public class ReportsInMemoryRepository : IReportsRepository
    {
        private static List<InventoryReport> inventories = new List<InventoryReport>
        {
            new InventoryReport
            {
                InventoryId = 1,
                Year = 2001,
                Make = "Honda",
                Model = "Civic",
                Count = 2,
                StockValue = 20000,
                Condition = "New"
            },
            new InventoryReport
            {
                InventoryId = 2,
                Year = 2002,
                Make = "Ford",
                Model = "Forder",
                Count = 3,
                StockValue = 30000,
                Condition = "New"
            },
            new InventoryReport
            {
                InventoryId = 3,
                Year = 2003,
                Make = "Honda",
                Model = "Civic",
                Count = 3,
                StockValue = 30000,
                Condition = "Used"
            },
            new InventoryReport
            {
                InventoryId = 4,
                Year = 2004,
                Make = "Ford",
                Model = "Derger",
                Count = 5,
                StockValue = 30000,
                Condition = "Used"
            },
        };
        private static List<SalesReport> sales = new List<SalesReport>
        {
            new SalesReport
            {
                User = "Tom Cotton",
                TotalSales = 120000,
                TotalVehicles = 12
            },
            new SalesReport
            {
                User = "James Dean",
                TotalSales = 1200000,
                TotalVehicles = 120
            },
            new SalesReport
            {
                User = "Ted Gunderson",
                TotalSales = 40000,
                TotalVehicles = 5
            },
            new SalesReport
            {
                User = "Karen Karenson",
                TotalSales = 1200,
                TotalVehicles = 1
            }           
        };
        public List<InventoryReport> GetNew()
        {
            return inventories.FindAll(o => o.Condition == "New");
        }

        //public List<SalesReport> GetSalesReports(string User, DateTime? fromDate, DateTime? toDate)
        //{
        //    var salesReport = GetSalesReports();
        //    if (!string.IsNullOrEmpty(User))
        //    {
        //        salesReport = sales.FindAll(o => o.User.ToString() == User);
        //    }
        //    else
        //    {
        //        salesReport.OrderBy(o => o.TotalSales);

        //    }
        //    return salesReport.ToList();
        //}

        public List<SalesReport> GetSalesReports(string User, DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
        }

        public List<InventoryReport> GetUsed()
        {
            return inventories.FindAll(o => o.Condition == "Used");
        }
    }
}
