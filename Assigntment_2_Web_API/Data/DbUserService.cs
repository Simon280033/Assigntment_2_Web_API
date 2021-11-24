using System;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Models;

namespace Assigntment_2_Web_API
{
    public class DbUserService : IUserService
    {
        private AdultsAndUsersDbContext _usersAndUsersDbContext;

        public DbUserService()
        {
            this._usersAndUsersDbContext = new AdultsAndUsersDbContext();
        }

        public async Task<User> ValidateUser(string userName, string passWord)
        {
            User user = _usersAndUsersDbContext.Users.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(passWord));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");        
        }
        
        public async Task<User> GetUser(string userName)
        {
            Console.WriteLine("Getting user...");
            User user = _usersAndUsersDbContext.Users.FirstOrDefault(u => u.UserName.Equals(userName));
            if (user != null)
            {
                return user;
            }
            else
            {
                return new User(); // Client receives an empty user if none exists
            }
            throw new Exception("User not found");        
        }

        public async Task<User> AddUserAsync(User user)
        {
            Console.WriteLine("Adding user...");
            _usersAndUsersDbContext.Users.Add(user);
            _usersAndUsersDbContext.SaveChanges();
            return user;
        }
    }
}