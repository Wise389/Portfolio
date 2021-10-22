using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    //Correct Naming convention is ModelsDTO
    public class ModelsTable
    {
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public DateTime DateTime { get; set; }
        public string UserEmail { get; set; }
        public ModelsTable()
        {
            MakeName = "";
            ModelName = "";
            DateTime = DateTime.Now;
            UserEmail = "";
        }

    }
}
