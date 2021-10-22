using CarDealership.BLL;
using CarDealership.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles ="sales")]
    public class SalesController : Controller
    {
        //This allows you do use methods in the operations manager class from your controller.
        private OperationManager operationsManager = new OperationManager();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Purchase(int id)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            var vehicle = operationsManager.GetVehicleByID(id);
            purchaseViewModel.Vehicle = vehicle;
            return View(purchaseViewModel);
        }
        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel vm)
        {
            if (((vm.Sale.Customer.Phone ?? "").ToString().Length < 10 || (vm.Sale.Customer.Phone ?? "").ToString().Length > 10) && string.IsNullOrEmpty(vm.Sale.Customer.Email))
            {
                ModelState.AddModelError("Customer.Email", "Either Email or Phone Number is required.");
                ModelState.AddModelError("Customer.Phone", "Either Email or Phone Number is required, Phone Number is required to be 10 digits long");
            }
            if (string.IsNullOrEmpty(vm.Sale.Customer.Name))
            {
                ModelState.AddModelError("Customer.Name" ,"Name is required");
            }
            if (string.IsNullOrEmpty(vm.Sale.Customer.Street1))
            {
                ModelState.AddModelError("Customer.Street1", "Street Address 1 is required");
            }
            if (string.IsNullOrEmpty(vm.Sale.Customer.City))
            {
                ModelState.AddModelError("Customer.City", "City is required");
            }
            if (vm.Sale.Customer.Zipcode.ToString().Length < 5 || vm.Sale.Customer.Zipcode.ToString().Length > 5)
            {
                ModelState.AddModelError("Customer.Zipcode", "Zipcode is required and must be 5 digits long");
            }
            if (vm.Sale.PurchasePrice < (vm.Vehicle.MSRP * 0.95m) || vm.Sale.PurchasePrice > vm.Vehicle.MSRP || vm.Sale.PurchasePrice < 0)
            {
                ModelState.AddModelError("Vehicle.PurchasePrice", "Purchase Price cannot exceed the MSRP or be less than 95% of MSRP");        
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.Sale.Vehicle.VehicleId = vm.Vehicle.VehicleId;
            vm.Sale.SalesPerson = User.Identity.Name;
            vm.Sale.SalesDate = DateTime.Now;
            operationsManager.CreateSale(vm.Sale);

            return RedirectToAction("Index", "Sales");
        }
        
    }
}