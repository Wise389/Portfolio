using CarDealership.Models;
using CarsDealership.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Repository
{
    public class UserInMemoryRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User
            {
                UserId = "1",
                FirstName = "Ted",
                LastName = "Stevens",
                Email = "TS@Email.com",
                Role = CarDealership.Models.Enumerations.Role.Admin,
                Password = "testing123",
                ConfirmationPassword = "testing123"

            },
            new User
            {
                UserId = "2",
                FirstName = "Greg",
                LastName = "Gregson",
                Email = "GG@Email.com",
                Role = CarDealership.Models.Enumerations.Role.Sales,
                Password = "testing123",
                ConfirmationPassword = "testing123"
            },
            new User
            {
                UserId = "3",
                FirstName = "Bill",
                LastName = "Burr",
                Email = "BB@Email.com",
                Role = CarDealership.Models.Enumerations.Role.Disabled,
                Password = "testing123",
                ConfirmationPassword = "testing123"

            },
        };
        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(string id)
        {
            return users.FirstOrDefault(o => o.UserId == id);
        }

        public void RemoveDuplicates(string userId, string roleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserName(string userId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
