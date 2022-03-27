using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GeekBrains.TimeSheets.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
<<<<<<< HEAD:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/PersonsController.cs
        private readonly IPersonRepository _dbRepository;
        private readonly MapperService _mapper;
        public PersonsController(IPersonRepository dbRepository, MapperService mapper)
        {
            _dbRepository = dbRepository;
=======
        private readonly MapperService _mapper;
        private readonly IRepository<EmployeeContext> _database;
        public EmployeesController(MapperService mapper, IRepository<EmployeeContext> database)
        {
>>>>>>> lesson4:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/EmployeesController.cs
            _mapper = mapper;
            _database = database;
        }

<<<<<<< HEAD:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/PersonsController.cs
        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            try
            {
                var result = await _dbRepository.GetPersonByIdAsync(id);
                return Ok(_mapper.Map(result));
            }
            catch(PersonFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/search")]
        public async Task<IActionResult> GetPersonByName([FromQuery] string searchTerm)
        {
            try
            {
                var result = await _dbRepository.GetPersonByNameAsync(searchTerm);
                return Ok(_mapper.Map(result));
=======
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create([FromBody] EmployeeDTO dto)
        {
            try
            {
                await _database.Create(_mapper.Map(dto));
                return Ok();
>>>>>>> lesson4:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/EmployeesController.cs
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
<<<<<<< HEAD:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/PersonsController.cs
                var result = await _dbRepository.GetPersonsByIdAsync(skip, take);
                return Ok(_mapper.Map(result));
            }
            catch (ArgumentException)
=======
                var data = await _database.Read(id);
                return Ok(_mapper.Map(data));
            }
            catch(System.InvalidOperationException)
>>>>>>> lesson4:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/EmployeesController.cs
            {
                return NotFound();
            }
        }

<<<<<<< HEAD:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/PersonsController.cs
        [HttpPost]
        public async Task<IActionResult> AddPerson([FromServices] MapperService mapper, [FromBody] PersonDTO person)
        {
            try
            {
                await _dbRepository.AddPersonAsync(mapper.Map(person));
                return Ok();
            }
            catch (PersonFoundException)
            {
                return BadRequest();
            }
        }

=======
>>>>>>> lesson4:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/EmployeesController.cs
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] EmployeeDTO dto)
        {
            try
            {
<<<<<<< HEAD:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/PersonsController.cs
                await _dbRepository.ChangePersonAsync(mapper.Map(person));
=======
                await _database.Update(_mapper.Map(dto));
>>>>>>> lesson4:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/EmployeesController.cs
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
<<<<<<< HEAD:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/PersonsController.cs
                await _dbRepository.DeletePersonByIdAsync(id);
=======
                await _database.Delete(id);
>>>>>>> lesson4:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/Controllers/EmployeesController.cs
                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
