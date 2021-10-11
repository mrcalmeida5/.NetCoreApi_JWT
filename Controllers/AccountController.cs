using CoreApi_JWT.Models;
using CoreApi_JWT.Repositories;
using CoreApi_JWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreApi_JWT.Controllers
{
    [ApiController]
    [Route("v1/account")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly JwtTokenService _jwtService;
        public AccountController(JwtTokenService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody]User user)
        {
            var userDB = UsersRepository.Get(user.Username, user.Password);

            if (userDB == null)
                return NotFound(new
                {
                    messsage = "User or password invalid"
                });

            var token = _jwtService.GenerateToken(userDB);
            userDB.Password = string.Empty;

            return new
            {
                user = userDB,
                token = token
            };
        }
    }
}
