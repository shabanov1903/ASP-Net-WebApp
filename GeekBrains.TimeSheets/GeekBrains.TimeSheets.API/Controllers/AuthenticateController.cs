using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text;

namespace GeekBrains.TimeSheets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IFind<UserContext, Expression<Func<UserContext, bool>>> _finder;
        private readonly UserService _user;
        private readonly IRepository<UserContext> _database;
        public AuthenticateController(UserService user, 
                                      IFind<UserContext, Expression<Func<UserContext, bool>>> finder,
                                      IRepository<UserContext> database)
        {
            _user = user;
            _finder = finder;
            _database = database;
        }

        [HttpGet]
        [Route("gettoken")]
        public async Task<IActionResult> GetToken([FromQuery] string login, [FromQuery] string password)
        {
            try
            {
                var element = await _finder.FindElement(x => x.Username == login);
                if (!_user.CheckHashPassword(element.PasswordHash, password, element.Salt)) return NotFound();
                var data = _user.Authenticate(element.Id.ToString());
                element.RefreshToken = data.RefreshToken;
                await _database.Update(element);
                SetTokenCookie(data.RefreshToken);
                return Ok(data);
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            var gettingToken = Request.Cookies["refreshToken"];
            var element = await _finder.FindElement(x => x.RefreshToken == gettingToken);
            if (element.RefreshToken != gettingToken) return NotFound();
            var data = _user.RefreshToken(element.Id.ToString());
            element.RefreshToken = data.RefreshToken;
            await _database.Update(element);
            SetTokenCookie(data.RefreshToken);
            return Ok(data);
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
