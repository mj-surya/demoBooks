using BookStoreApp.Interface;
using BookStoreApp.Models.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public ActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            string message = "";
            try
            {
                var user = _userService.Register(userRegisterDTO);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException)
            {
                message = "Username already exists";
            }
            catch (Exception)
            {
                message="Could not register user";
            }
            return BadRequest(message);
        }
        [HttpPost("login")]
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized("Invalid username or password");
        }
        [HttpGet("Get")]
        public ActionResult GetUser(string id)
        {
            var result = _userService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Invalid username");
        }
    }
}
