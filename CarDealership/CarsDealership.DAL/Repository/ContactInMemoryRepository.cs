using CarDealership.Models;
using CarsDealership.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Repository
{
    public class ContactInMemoryRepository : IContactRepository
    {
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact
            {
                ContactId = 1,
                Name = "Jon Wise",
                Email = "wisejg89@gmail.com",
                Phone = "3303533553",
                Message = "",
            }
        };

        public void Create(Contact contact)
        {
            contacts.Add(contact);
        }
    }
}
