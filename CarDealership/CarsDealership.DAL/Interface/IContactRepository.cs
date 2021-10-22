using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Interface
{
    public interface IContactRepository
    {
        void Create(Contact contact);

    }
}
