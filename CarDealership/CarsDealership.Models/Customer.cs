using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Enumerations;

namespace CarDealership.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        public string Phone { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        //[Required]
        public string City { get; set; }
        //[Required]
        public State State { get; set; }
        public int Zipcode { get; set; }
        public Customer()
        {
            Name = "";
            Phone = "";
            Email = "";
            Street1 = "";
            Street2 = "";
            City = "";
            State = State.CO;
            Zipcode = 90210;
        }
    }
    
}
