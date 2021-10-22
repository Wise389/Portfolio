using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class AddVehicleRequest
    {
        public Vehicle Vehicle { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
    }
}
