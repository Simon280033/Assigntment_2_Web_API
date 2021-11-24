using System.Threading.Tasks;
using Models;

namespace Assigntment_2_Web_API
{
    public interface IUserService
    {
        Task<User> GetUser(string userName);
        
        Task<User>   AddUserAsync(User user);
    }
}