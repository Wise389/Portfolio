using CarDealership.BLL;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using CarDealership.UI.Models;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using CarDealership.UI;
using System.IO;
using CarDealership.Models.Enumerations;
using System.Threading.Tasks;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {    
        public AdminController()
        {
        }


        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private OperationManager operationManager = new OperationManager();

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            var models = operationManager.GetAllModels();
            var makes = operationManager.GetAllMakes();
            var newVehicleVM =  new AddVehicleViewModel();
            newVehicleVM.Vehicle = new Vehicle();
            newVehicleVM.Models = models.Select(model => new System.Web.Mvc.SelectListItem { Text = model.ModelName, Value = model.ModelId.ToString() }).ToList();
            newVehicleVM.Makes = makes.Select(make => new System.Web.Mvc.SelectListItem { Text = make.MakeName, Value = make.MakeId.ToString() }).ToList();
            
            return View(newVehicleVM);
;       }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel viewModel, HttpPostedFileBase file)
        {
            var makes = operationManager.GetAllMakes();
            var models = operationManager.GetAllModels();         
            viewModel.Makes = makes.Select(make => new System.Web.Mvc.SelectListItem { Text = make.MakeName, Value = make.MakeId.ToString() }).ToList();
            viewModel.Models = models.Select(model => new System.Web.Mvc.SelectListItem { Text = model.ModelName, Value = model.ModelId.ToString() }).ToList();
            
            var condition = viewModel.Vehicle.Condition;
            if (viewModel.Vehicle.Year < 2000 || viewModel.Vehicle.Year > (DateTime.Now.Year + 1))
            {
                ModelState.AddModelError("Vehicle.Year", "Please enter a valid year between 2000 and next year.");
            }
            if (viewModel.Vehicle.Condition == Condition.New)
            {
                if (viewModel.Vehicle.Mileage <= 0 || viewModel.Vehicle.Mileage > 1000)
                {
                    ModelState.AddModelError("Vehicle.Mileage", "New Vehicles must have a mileage greater than zero and 1000 or less");
                }
            }
            if (viewModel.Vehicle.Condition == Condition.Used)
            {
                if (viewModel.Vehicle.Mileage <= 1000)
                {
                    ModelState.AddModelError("Vehicle.Mileage", "Used Vehicles must have a mileage greater than 1000");
                }
            }
            if (string.IsNullOrEmpty(viewModel.Vehicle.Description))
            {
                ModelState.AddModelError("Vehicle.Description", "A description is required");
            }
            if (viewModel.Vehicle.MSRP < 0)
            {
                ModelState.AddModelError("Vehicle.MSRP", "MSRP has to be a positive number");
            }
            if (string.IsNullOrEmpty(viewModel.Vehicle.VIN))
            {
                ModelState.AddModelError("Vehicle.VIN", "A VIN is required");
            }
            if (viewModel.Vehicle.SalesPrice < 0 || viewModel.Vehicle.SalesPrice < (viewModel.Vehicle.MSRP * .95m) || viewModel.Vehicle.SalesPrice > viewModel.Vehicle.MSRP)
            {
                ModelState.AddModelError("Vehicle.SalesPrice", "Sales price must be positive and no less than 95% of MSRP");
            }
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.Vehicle.Make = makes.Find(o => o.MakeId == viewModel.Vehicle.Make.MakeId);
            viewModel.Vehicle.Model =  models.Find(o => o.ModelId == viewModel.Vehicle.Model.ModelId);

            var newId = Guid.NewGuid();

            string filename = "inventory-" + newId + ".jpg";
            string _path = Path.Combine(Server.MapPath("~/images/"), filename);
            if (!System.IO.File.Exists(_path))
            {
                System.IO.File.Create(_path).Close();
            }
            file.SaveAs(_path);
            

            viewModel.Vehicle.ImgUrl = "/images/" + filename;

            var id = operationManager.AddVehicle(viewModel.Vehicle);

            return RedirectToAction("EditVehicle/" + id, "Admin");
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            var vehicle = operationManager.GetVehicleByID(id);
            var models = operationManager.GetAllModels();
            var makes = operationManager.GetAllMakes();
            var newVehicle = new EditVehicleViewModel();
            newVehicle.Vehicle = vehicle;
            newVehicle.Models = models.Select(model => new System.Web.Mvc.SelectListItem { Text = model.ModelName, Value = model.ModelId.ToString(), Selected = model.ModelId ==  vehicle.Model.ModelId }).ToList();
            newVehicle.Makes = makes.Select(make => new System.Web.Mvc.SelectListItem { Text = make.MakeName, Value = make.MakeId.ToString(), Selected = make.MakeId == vehicle.Make.MakeId }).ToList();
            return View(newVehicle);
        }

        [HttpPost]
        public ActionResult EditVehicle(EditVehicleViewModel viewModel, HttpPostedFileBase file)
        {

            var condition = viewModel.Vehicle.Condition;
            if (viewModel.Vehicle.Year < 2000 || viewModel.Vehicle.Year > (DateTime.Now.Year + 1))
            {
                ModelState.AddModelError("Vehicle.Year", "Please enter a valid year between 2000 and next year.");
            }
            if (viewModel.Vehicle.Condition == Condition.New)
            {
                if (viewModel.Vehicle.Mileage <= 0 || viewModel.Vehicle.Mileage > 1000)
                {
                    ModelState.AddModelError("Vehicle.Mileage", "New Vehicles must have a mileage greater than zero and 1000 or less");
                }
            }
            if (viewModel.Vehicle.Condition == Condition.Used)
            {
                if (viewModel.Vehicle.Mileage <= 1000)
                {
                    ModelState.AddModelError("Vehicle.Mileage", "Used Vehicles must have a mileage greater than 1000");
                }
            }
            if (string.IsNullOrEmpty(viewModel.Vehicle.Description))
            {
                ModelState.AddModelError("Vehicle.Description", "A description is required");
            }
            if (viewModel.Vehicle.MSRP < 0)
            {
                ModelState.AddModelError("Vehicle.MSRP", "MSRP has to be a positive number");
            }
            if (string.IsNullOrEmpty(viewModel.Vehicle.VIN))
            {
                ModelState.AddModelError("Vehicle.VIN", "A VIN is required");
            }
            if (viewModel.Vehicle.SalesPrice < 0 || viewModel.Vehicle.SalesPrice < (viewModel.Vehicle.MSRP * .95m) || viewModel.Vehicle.SalesPrice > viewModel.Vehicle.MSRP)
            {
                ModelState.AddModelError("Vehicle.SalesPrice", "Sales price must be positive and no less than 95% of MSRP");
            }
            if (string.IsNullOrEmpty(viewModel.Vehicle.ImgUrl))
            {
                ModelState.AddModelError("Vehicle.ImgUrl", "Vehicle requires an image");
            }
            if (!ModelState.IsValid)
            {
                var models = operationManager.GetAllModels();
                var makes = operationManager.GetAllMakes();
                viewModel.Models = models.Select(model => new System.Web.Mvc.SelectListItem { Text = model.ModelName, Value = model.ModelId.ToString(), Selected = model.ModelId == viewModel.Vehicle.Model.ModelId }).ToList();
                viewModel.Makes = makes.Select(make => new System.Web.Mvc.SelectListItem { Text = make.MakeName, Value = make.MakeId.ToString(), Selected = make.MakeId == viewModel.Vehicle.Make.MakeId }).ToList();
                return View(viewModel);
            }

            if (file != null)
            {
                var newId = Guid.NewGuid();
                var filename = "inventory-" + newId + ".jpg";
                var _path = Path.Combine(Server.MapPath("~/images/"), filename);

                if (!System.IO.File.Exists(_path))
                {
                    System.IO.File.Create(_path).Close();
                }
                file.SaveAs(_path);
                viewModel.Vehicle.ImgUrl = "/images/" + filename;
            }

            operationManager.EditVehicle(viewModel.Vehicle);

            return RedirectToAction("Vehicles", "Admin");
        }

        [HttpDelete]
        public ActionResult DeleteVehicle(int id)
        {
            var vehicle = operationManager.GetVehicleByID(id);
            operationManager.DeleteVehicle(id);
            if (!string.IsNullOrEmpty(vehicle.ImgUrl))
            {
                System.IO.File.Delete(Path.Combine(vehicle.ImgUrl.Substring(7)));
            }           
            return View("Vehicles");
        }

        [HttpGet]
        public ActionResult Makes()
        {
            var makes = operationManager.GetAllMakes();
            var vm = new MakesViewModel();
            vm.Makes = makes;
            
            return View(vm);
        }

        [HttpPost]
        public ActionResult Makes(MakesViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Make.MakeName))
            {
                ModelState.AddModelError("Make.MakeName", "Make Name is required.");
            }
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var newMake = new Make()
            {
                MakeName = viewModel.Make.MakeName,
                DateAdded = DateTime.Now,
                UserID = User.Identity.GetUserId()

            };
            operationManager.AddMake(newMake);
            return RedirectToAction("Makes", "Admin");
        }
         
        [HttpGet]
        public ActionResult Models()
        {
            var models = operationManager.GetAllModels();
            var makes = operationManager.GetAllMakes();
            var vm = new ModelsViewModel();
            vm.Makes = makes.Select(make => new System.Web.Mvc.SelectListItem { Text = make.MakeName, Value = make.MakeId.ToString() }).ToList();

            vm.Model = new Model();
            vm.Models = models;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Models(ModelsViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Model.ModelName))
            {
                ModelState.AddModelError("Model.ModelName", "Model Name is required.");
            }
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            viewModel.Model.DateAdded = DateTime.Now;
            viewModel.Model.UserEmail = "";
            viewModel.Model.UserID = User.Identity.GetUserId();                
            operationManager.AddModel(viewModel.Model);
            return RedirectToAction("Models", "Admin");
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var specialsVM = new SpecialsViewModel();
            specialsVM.Specials = operationManager.GetAllSpecials();
            return View(specialsVM);
        }
        [HttpPost]
        public ActionResult Specials(SpecialsViewModel vm, HttpPostedFileBase file)
        {
            if (string.IsNullOrEmpty(vm.Special.SpecialTitle))
            {
                ModelState.AddModelError("Special.SpecialTitle", "A title is required");
            }
            if (string.IsNullOrEmpty(vm.Special.SpecialMessage))
            {
                ModelState.AddModelError("Special.SpecialMessage", "A message is required");
            }
            if (!ModelState.IsValid)
            {
                vm.Specials = operationManager.GetAllSpecials();
                return View(vm);
            }
            var specials = new Special 
            {
                SpecialMessage = vm.Special.SpecialMessage,
                SpecialTitle = vm.Special.SpecialTitle
            };
            var newId = Guid.NewGuid();
        
            string filename = "special-" + newId + ".jpg";
            string _path = Path.Combine(Server.MapPath("~/images/"), filename);
            if (!System.IO.File.Exists(_path))
            {
                System.IO.File.Create(_path).Close();
            }
            file.SaveAs(_path);
            specials.ImageFilePath = "/images/" + filename;

            operationManager.AddSpecial(specials);
            return RedirectToAction("Specials", "Admin");
        }
        [HttpDelete]
        public ActionResult DeleteSpecial(int id)
        {
            operationManager.DeleteSpecial(id);

            return new JsonResult(){Data = "https://localhost:44380/Admin/Specials", JsonRequestBehavior = JsonRequestBehavior.AllowGet };         
        }
         
        [HttpGet]
        public ActionResult AddUser()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {         
            var newUser = new AppUser()
            {
                Email = user.Email,
                UserName = user.FirstName + " " + user.LastName,
            };
            var result = await UserManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                UserManager.AddToRole(newUser.Id, user.Role.ToString());
            }
            var model = operationManager.GetAllUsers();
            return View("Users", model);
        }
        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var user = operationManager.GetUserById(id);
            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> EditUser(User user)
        {
            var currentUser = UserManager.FindById(user.UserId);
            var userToModify = UserManager.FindById(user.UserId);

            var oldRoleId = currentUser.Roles.SingleOrDefault().RoleId;            
            var oldRoleName = UserManager.GetRoles(currentUser.Id).FirstOrDefault() ?? "";

            userToModify.UserName = user.FirstName + " " + user.LastName;
            userToModify.Email = user.Email;

            if (!String.IsNullOrEmpty(user.Password) && !String.IsNullOrEmpty(user.ConfirmationPassword) && user.Password == user.ConfirmationPassword)
            {
                userToModify.PasswordHash = UserManager.PasswordHasher.HashPassword(user.Password);
            }
            var result = await UserManager.UpdateAsync(userToModify);
            if (user.Role.ToString().ToLower() != oldRoleName.ToString().ToLower())
            {         
                if (result.Succeeded)
                {
                    UserManager.AddToRole(userToModify.Id, user.Role.ToString());
                    operationManager.RemoveDuplicates(currentUser.Id, oldRoleId);
                }
            }
            return RedirectToAction("Users");
        }
        
        public ActionResult Users()
        {
            var users = operationManager.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult Vehicles()
        {
            var vehicles = operationManager.GetAllVehicles();
            return View(vehicles);
        }
        
    }
}