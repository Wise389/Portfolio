using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ModelsViewModel
    {
        public List<System.Web.Mvc.SelectListItem> Makes { get; set; }

        public List<Model> Models { get; set; }

        public Model Model { get; set; }
        public ModelsViewModel()
        {
            Makes = new List<System.Web.Mvc.SelectListItem>();
            Models = new List<Model>();
            Model = new Model();
        }
    }

}