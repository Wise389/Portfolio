using CarDealership.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDealership.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {
        private OperationManager operationManager = new OperationManager();

        [Route("newSearch")]
        [HttpGet]
        public IHttpActionResult GetNewVehicle(string searchString, int? minPrice, int?  maxPrice, int? minYear, int? maxYear)
        {
            return Ok(operationManager.GetNewVehicleSearch(minPrice, maxPrice, minYear, maxYear, searchString));
        }

        [Route("usedSearch")]
        [HttpGet]
        public IHttpActionResult GeUsedVehicle(string searchString, int? minPrice, int? maxPrice, int? minYear, int? maxYear)
        {
            return Ok(operationManager.GetUsedVehicleSearch(minPrice, maxPrice, minYear, maxYear, searchString));
        }
        [Route("salesSearch")]
        [HttpGet]
        public IHttpActionResult GetSales(string searchString, int? minPrice, int? maxPrice, int? minYear, int? maxYear)
        {
            return Ok(operationManager.GetSearchedSales(minPrice, maxPrice, minYear, maxYear, searchString));
        }
        [Route("vehiclesSearch")]
        [HttpGet]
        public IHttpActionResult GetVehicles(string searchString, int? minPrice, int? maxPrice, int? minYear, int? maxYear)
        {
            return Ok(operationManager.GetSearchedVehicles(minPrice, maxPrice, minYear, maxYear, searchString));
        }
        [Route("salesReportSearch")]
        [HttpGet]
        public IHttpActionResult GetSales (string User, DateTime? StartDate, DateTime? EndDate)
        {
            return Ok(operationManager.GetSalesReports(User, StartDate, EndDate));
        }
        [Route("associatedModels")]
        [HttpGet]
        public IHttpActionResult GetModels(int MakeId)
        {
            var allModels = operationManager.GetAllModels();
            var selectModels = allModels.FindAll(o => o.Make.MakeId == MakeId);
            var selectedModels = selectModels.Select(model => new System.Web.Mvc.SelectListItem { Text = model.ModelName, Value = model.ModelId.ToString() }).ToList();     
            return Ok(selectedModels);
        }
    }
}