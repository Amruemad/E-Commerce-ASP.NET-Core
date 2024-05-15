using Ecommerce.DTOs.AppUsers;
using Ecommerce.Models.Models;
using Ecommerce.Service.Contract;
using Ecommerce.Service.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAppUserService appUserService;
        ITokenService tokenService;
        
        public AccountController(IAppUserService _appUserService, ITokenService _tokenService)
        {
            appUserService = _appUserService;
            tokenService = _tokenService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await appUserService.GetAllUsers();

            if (users == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(users);
            }
        }


        [HttpGet("user")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await appUserService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await appUserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }


        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateOrUpdateUserDTO userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var createdResult = await appUserService.Create(userDto);

                if (createdResult is UserDTO)
                {
                    return Ok(createdResult);
                }
                else
                {
                    return StatusCode(500, createdResult);
                }
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LogUserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var loggedUser = await appUserService.Login(userDto);

            if(loggedUser is UserDTO)
            {
                return Ok(loggedUser);
            }
            else
            {
                return NotFound(loggedUser);
            }
        }

        [HttpDelete("delete/{id:int}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            bool deleteResult = await appUserService.DeleteUser(id);
            if (deleteResult)
            {
                return Ok("Deleted Successfuly");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
