using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Interface
{
    public interface IUserRepository
    {
        User GetUserById(string id);
        List<User> GetAllUsers();
        void RemoveDuplicates(string userId, string roleId);
        void UpdateUserName(string userId, string userName);


    }
}
