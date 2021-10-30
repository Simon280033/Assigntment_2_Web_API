using System;
using System.Threading.Tasks;
using Assigntment_2_Web_API;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AdvancedTodoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<User> ValidateUser([FromQuery] string username)
        {
            try
            {
                User user = await userService.GetUser(username);
                Console.WriteLine("User to return: " + user.UserName);
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                User added = await userService.AddUserAsync(user);
                return Created($"/{added.UserName}", added); // return newly added adult, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}