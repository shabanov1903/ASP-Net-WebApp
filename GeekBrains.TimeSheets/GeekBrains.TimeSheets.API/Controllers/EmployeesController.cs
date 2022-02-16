using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GeekBrains.TimeSheets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MapperService _mapper;
        private readonly IRepository<EmployeeContext> _database;
        public EmployeesController(MapperService mapper, IRepository<EmployeeContext> database)
        {
            _mapper = mapper;
            _database = database;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create([FromBody] EmployeeDTO dto)
        {
            try
            {
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
        public async Task<IActionResult> Update([FromBody] EmployeeDTO dto)
        {
            try
            {
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
