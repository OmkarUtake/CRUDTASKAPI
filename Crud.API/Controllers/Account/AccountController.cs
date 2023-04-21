using Crud.Model.Account;
using Crud.ModelDTO.Account;
using Crud.Services.UserService;
using Crud.UtilityHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            var token = _userService.Authenticate(login);
            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }

        [HttpPost("User")]
        public async Task SignUp(User user)
        {
            await _userService.Add(user);
        }
    }
}
