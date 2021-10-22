using CarDealership.BLL;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class InventoryController : Controller
    {
         private OperationManager operationManager = new OperationManager();
        //TODO
        // Add get and post 
        [HttpGet]
        public ActionResult New()
        {
            var New = operationManager.FindNew();
            return View(New);
        }
        [HttpGet]
        public ActionResult Used()
        {
            var Used = operationManager.FindUsed();
            return View(Used);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var vehicle = operationManager.GetVehicleByID(id);
            return View(vehicle);
        }


    }
}