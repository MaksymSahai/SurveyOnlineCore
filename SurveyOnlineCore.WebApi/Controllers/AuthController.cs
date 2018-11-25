using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SurveyOnlineCore.Data.Interfaces;
using SurveyOnlineCore.Model.Models;

namespace SurveyOnlineCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]CustomerCreate customerCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                customerCreate.CustomerName = customerCreate.CustomerName.ToLower();

                if (await _authRepository.CustomerExists(customerCreate.CustomerName))
                    return BadRequest("Customer with this name already exists");

                var customer = Model.Mappers.CustomerMapper.Map(customerCreate);
                var createdCustomer = await _authRepository.Register(customer, customerCreate.CustomerPassword);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]CustomerLogin customerLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var customer = await _authRepository.Login(customerLogin.CustomerName.ToLower(), customerLogin.CustomerPassword);

                if (customer == null)
                    return Unauthorized();

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                    new Claim(ClaimTypes.Name, customer.CustomerName)
                };
                
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token) });
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}