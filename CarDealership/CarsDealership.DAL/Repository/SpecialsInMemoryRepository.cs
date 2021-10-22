using CarDealership.Models;
using CarsDealership.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Repository
{
    public class SpecialsInMemoryRepository : ISpecialsRepository
    {
        private static List<Special> specials = new List<Special>
        {

            new Special
            {
                SpecialId = 1,
                SpecialTitle = "Once on Fire 80% Off",
                SpecialMessage = "Do you like bonfires, this car will remind you of a cozy fire in a log cabin, while most this car is ruined it has an amazing aroma",
                ImageFilePath = "/images/inventory-aa88a673-3150-457b-abb6-6c2708916171.jpg"
            },
            new Special
            {
                SpecialId = 2,
                SpecialTitle = "Shines Like a Diamond 30% Off",
                SpecialMessage = "This vehicle got caught a truck load of glitter and is the perfect excuse for the man who was working late, deemed as Rapper's Delight",
                ImageFilePath = "/images/inventory-ae3a8237-c443-41ae-853a-8b2d99e81c57.jpg"
            }
        };
        public void Create(Special special)
        {
            special.SpecialId = specials.Max(o => o.SpecialId) + 1;
            specials.Add(special);
        }

        public void Delete(int id)
        {
            var toDelete = specials.FirstOrDefault(o => o.SpecialId == id);
            specials.Remove(toDelete);
        }

        public List<Special> GetAll()
        {
            return specials;
        }

        public Special GetById(int id)
        {
            return specials.FirstOrDefault(o => o.SpecialId == id);
        }
    }
}
