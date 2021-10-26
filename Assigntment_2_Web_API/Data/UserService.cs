using System;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Models;

namespace Assigntment_2_Web_API
{
    public class UserService : IUserService
    {
        private UsersHandler uh;

        public UserService()
        {
            this.uh = new UsersHandler();
        }

        public async Task<User> ValidateUser(string userName, string passWord)
        {
            User user = uh.Users.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(passWord));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");        }
    }
}