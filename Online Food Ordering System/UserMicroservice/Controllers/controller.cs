using Microsoft.AspNetCore.Mvc;
using Online_Food_Ordering_System.UserMicroservice.Business_Layer.DTO;
using Online_Food_Ordering_System.UserMicroservice.Business_Layer.Service;

namespace Online_Food_Ordering_System.UserMicroservice.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            try
            {
                _userService.RegisterUser(userDto);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDto)
        {
            try
            {
                var token = _userService.Login(userLoginDto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add other API endpoints for user-related operations such as fetching user details, updating user information, etc.
    }
}
