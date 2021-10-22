using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarDealership.Models
{
    public class Make
    {
        public int MakeId { get; set;}
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserEmail { get; set; }
        public string UserID { get; set; }
        public Make()
        {
            MakeName = "Honda";
            DateAdded = DateTime.Now;
            UserEmail = "";
            UserID = "";
        }
    }
}
