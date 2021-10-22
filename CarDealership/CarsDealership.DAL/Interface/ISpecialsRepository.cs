using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Interface
{
    public interface ISpecialsRepository
    {
        Special GetById(int id);
        List<Special> GetAll();
        void Create(Special special);
        void Delete(int id);
    }
}
