using CarDealership.BLL;
using CarDealership.Models;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        private OperationManager operationManager = new OperationManager();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Inventory()
        {
            var NewVehicles = operationManager.GetNew();
            var UsedVehicles = operationManager.GetUsed();
            InventoryReportViewModel inventoryReportViewModel = new InventoryReportViewModel()
            {
                NewVehicles = NewVehicles,
                UsedVehicles = UsedVehicles,
            };
            return View(inventoryReportViewModel);
        }
        [HttpGet]
        public ActionResult Sales()
        {
            //var sales = operationManager.GetAllSales();
            //var SoldCount = sales.FindAll(o => o.Vehicle.Sold).Count;
            var users = operationManager.GetAllUsers();
            var vm = new SalesReportViewModel();
            vm.Users = users.Select(user => new SelectListItem { Text = user.Email, Value = user.UserId.ToString() }).ToList();

            //var UserName = sales.FindAll(o => o.SalesPerson == User.Identity.Name);
            //var VehiclesSold = sales.FindAll(o => o.Vehicle.Sold).Count();
            

            //decimal TotalSales = 0;
            //foreach (var value in sales)
            //{
            //    TotalSales = value.SalesPrice + TotalSales;
            //}

            return View(vm);
        }
    }
}