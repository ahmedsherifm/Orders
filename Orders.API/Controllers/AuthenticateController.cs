using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using Orders.API.Core;
using Orders.API.Entities.Models;
using Orders.API.Models;
using Orders.API.Models.RequestModels;
using Orders.API.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orders.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly IAuthService _authService;

        public AuthenticateController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var response = await _authService.LoginUser(model);
            return string.Equals(response.Status, "Error", StringComparison.OrdinalIgnoreCase) ?
                StatusCode(StatusCodes.Status401Unauthorized, response) :
                Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var response = await _authService.RegisterUser(model);
            return string.Equals(response.Status, "Error", StringComparison.OrdinalIgnoreCase) ?
                StatusCode(StatusCodes.Status500InternalServerError, response) :
                Ok(response);
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var response = await _authService.RegisterAdmin(model);
            return string.Equals(response.Status, "Error", StringComparison.OrdinalIgnoreCase) ?
                StatusCode(StatusCodes.Status500InternalServerError, response) :
                Ok(response);
        }
    }
}