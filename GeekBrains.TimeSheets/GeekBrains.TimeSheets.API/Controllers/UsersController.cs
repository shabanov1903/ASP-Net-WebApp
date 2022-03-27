using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace GeekBrains.TimeSheets.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MapperService _mapper;
        private readonly UserService _user;
        private readonly IRepository<UserContext> _database;
        public UsersController(MapperService mapper, UserService user, IRepository<UserContext> database)
        {
            _mapper = mapper;
            _user = user;
            _database = database;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create([FromBody] UserDTO dto)
        {
            try
            {
                dto.Salt = Convert.ToBase64String(_user.GetNewSalt());
                dto.PasswordHash = Convert.ToBase64String(_user.HashPassword(dto.PasswordHash, Convert.FromBase64String(dto.Salt)));
                await _database.Create(_mapper.Map(dto));
                return Ok();
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }            
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Read([FromRoute] Guid id)
        {
            try
            {
                var data = await _database.Read(id);
                return Ok(_mapper.Map(data));
            }
            catch(System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UserDTO dto)
        {
            try
            {
                dto.Salt = Convert.ToBase64String(_user.GetNewSalt());
                dto.PasswordHash = Convert.ToBase64String(_user.HashPassword(dto.PasswordHash, Convert.FromBase64String(dto.Salt)));
                await _database.Update(_mapper.Map(dto));
                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("del/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _database.Delete(id);
                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
