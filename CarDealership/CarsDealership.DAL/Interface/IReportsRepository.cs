using CarsDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Interface
{
    public interface IReportsRepository
    {
        List<InventoryReport> GetNew();
        List<InventoryReport> GetUsed();
        List<SalesReport> GetSalesReports(string User, DateTime? fromDate, DateTime? toDate);
    }
}
