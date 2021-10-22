using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Special
    {
        public int SpecialId { get; set; }
        public string SpecialTitle { get; set; }
        public string SpecialMessage { get; set; }
        public string ImageFilePath { get; set; }
        public Special()
        {
            SpecialTitle = "";
            SpecialMessage = "";
            ImageFilePath = "";
        }
    }
}
