using CarDealership.BLL;
using CarDealership.Models;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        private OperationManager operationManager = new OperationManager();
        [HttpGet]
        public ActionResult Index()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.Featured = operationManager.GetAllFeatured();
            homePageViewModel.Specials = operationManager.GetAllSpecials();
            return View(homePageViewModel);
        }
        [HttpGet]
        public ActionResult Specials()
        {
            var specials = operationManager.GetAllSpecials();
            return View(specials);
        }
        [HttpGet]
        public ActionResult Contact(string vin)
        {
            var contact = new Contact
            {
                Message = vin,
            };
            return View(contact);
        }
        
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            //If the contact button on the Inventory/Details page was used to navigatehere, the VIN # of the vehicle should be placed into the message field
            if (string.IsNullOrEmpty(contact.Name))
            {
                ModelState.AddModelError("Name", "Your name is required");
            }
            if (string.IsNullOrEmpty(contact.Message))
            {
                ModelState.AddModelError("Message", "A Message is required");
            }
            if (string.IsNullOrEmpty(contact.Email) && string.IsNullOrEmpty(contact.Phone))  // && contact.Phone < 10 && contact.Phone > 10)
            {
                ModelState.AddModelError("Email", "An email address or Phone number are required");
                ModelState.AddModelError("Phone", "An email address or Phone number are required");
            }           
            if (!ModelState.IsValid)
            {
                return View("Contact");
            }

            operationManager.AddContact(contact);
            return RedirectToAction("Contact", "Home");
        }
        public ActionResult About()
        {
            return View();
        }
    }
}