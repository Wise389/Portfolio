 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Models.Enumerations;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public Condition Condition { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public int Year { get; set; }
        public Transmission Transmission { get; set; }
        public Color Color { get; set; }
        public Interior Interior { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public bool Featured { get; set; }
        public bool Sold { get; set; }
        public Vehicle()
        {
            Make = new Make();
            Model = new Model();
            Condition = Condition.New;
            BodyStyle = BodyStyle.Car;
            Year = 2000;
            Transmission = Transmission.Automatic;
            Color = Color.Black;
            Interior = Interior.Black;
            Mileage = 1000;
            VIN = "";
            MSRP = 1000;
            SalesPrice = 1000;
            Description = "";
            ImgUrl = "";
            Featured = false;
            Sold = false;
        }
    }
}
