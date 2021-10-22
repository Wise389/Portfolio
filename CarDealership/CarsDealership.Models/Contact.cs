using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //string
        public string Phone { get; set; }
        public string Message { get; set; }
        public Contact()
        {
            Name = "";
            Email = "";
            Phone = "";
            Message = "";
        }
    }
}
