using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.API.Controllers.Resources;
using HR.API.Helper;
using HR_DATA.HR_Module.UserMgt;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HR.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;

        public UserController(IUserRepository repo, IConfiguration config, IMapper mapper ,IUnitOfWork unitofwork)
        {
            _config = config;
            _repo = repo;
            _mapper = mapper;
            _unitofwork = unitofwork;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(SaveUserResource userForRegister)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userForRegister.Username = userForRegister.Username.ToLower();

            if (await _repo.UserExists(userForRegister.Username))
                return BadRequest("Username already exists");

            var UserToAdd = _mapper.Map<SaveUserResource, User>(userForRegister);
            var createdUser =  _repo.Register(UserToAdd, userForRegister.Password);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }

        //[AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserResource userForLogin)
        {
            var user=_mapper.Map<LoginUserResource,User>(userForLogin);
            var userFromRepo = await _repo.Login(user, userForLogin.Password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}