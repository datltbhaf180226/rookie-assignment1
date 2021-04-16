using Library.Models;
using Library.Repositoties;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;

namespace Library.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [Route("/loginFail")]
        public IActionResult Unauthorize()
        {
            return Unauthorized();
        }

        [Route("/acessDenied")]
        public IActionResult AccessDenied()
        {
            return StatusCode(403);
        }

        [HttpPost("login")]
        public async System.Threading.Tasks.Task<IActionResult> LoginAsync(User user)
        {
            var databaseUser = _repository.GetAll().Where(u => u.Username == user.Username && u.Password == user.Password).ToList();

            if (databaseUser.Count() != 0)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, databaseUser[0].Username.ToString()),
                    new Claim("Password", databaseUser[0].Password.ToString()),
                    new Claim(ClaimTypes.Role, databaseUser[0].Role.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddHours(3),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                

                return Ok(databaseUser);
            }
            return BadRequest("Ten dang nhap hoac mat khau khong chinh xac!");
        }

        [HttpPost("logout")]
        public async System.Threading.Tasks.Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Logout thanh cong");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var users = _repository.GetAll().ToList();

            if (users != null)
            {
                return Ok(users);
            }
            return BadRequest("Co loi xay ra!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _repository.Get(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("Khong tim thay book co id:" + id);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repository.Get(id);
            if (user != null)
            {
                _repository.Delete(user);
                return Ok(user);
            }
            return BadRequest("Khong tim thay book co id:" + id);
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid) return BadRequest("Co loi xay ra!");

            var entity = new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Role = (Role)1,
            };
            if (entity != null)
            {
                _repository.Insert(entity);
                return Ok(entity);
            }
            return BadRequest("Co loi xay ra!");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            if (!ModelState.IsValid) return BadRequest("Co loi xay ra!");

            var entity = _repository.Get(id);

            if (entity != null)
            {
                entity.Username = user.Username;
                entity.Password = user.Password;
                entity.Role = user.Role;
                _repository.Update(entity);
                return Ok(entity);
            }

            return BadRequest("Khong tim thay book co id la " + id!);
        }
    }
}