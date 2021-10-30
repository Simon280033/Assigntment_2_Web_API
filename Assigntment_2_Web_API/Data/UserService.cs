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
            throw new Exception("User not found");        
        }
        
        public async Task<User> GetUser(string userName)
        {
            User user = uh.Users.FirstOrDefault(u => u.UserName.Equals(userName));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");        
        }

        public async Task<bool> CheckIfUserExists(string userName)
        {
            User user = uh.Users.FirstOrDefault(u => u.UserName.Equals(userName));
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new Exception("User not found");              }

        public async Task<User> AddUserAsync(User user)
        {
            uh.Users.Add(user);
            uh.SaveChanges();
            return user;
        }
    }
}