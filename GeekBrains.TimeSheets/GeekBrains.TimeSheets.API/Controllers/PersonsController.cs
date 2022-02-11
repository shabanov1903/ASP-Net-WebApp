using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Exceptions;
using GeekBrains.TimeSheets.DB.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.TimeSheets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IRepository _dbController;
        private readonly MapperService _mapper;
        public PersonsController(IRepository dbController, MapperService mapper)
        {
            _dbController = dbController;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            try
            {
                var result = await _dbController.GetPersonByIdAsync(id);
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
                var result = await _dbController.GetPersonByNameAsync(searchTerm);
                return Ok(_mapper.Map(result));
            }
            catch (PersonFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonsById([FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                var result = await _dbController.GetPersonsByIdAsync(skip, take);
                return Ok(_mapper.Map(result));
            }
            catch (PersonFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromServices] MapperService mapper, [FromBody] PersonDTO person)
        {
            try
            {
                await _dbController.AddPersonAsync(mapper.Map(person));
                return Ok();
            }
            catch (PersonFoundException)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> ChangePerson([FromServices] MapperService mapper, [FromBody] PersonDTO person)
        {
            try
            {
                await _dbController.ChangePersonAsync(mapper.Map(person));
                return Ok();
            }
            catch (PersonFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("/{id}")]
        public async Task<IActionResult> DeletePersonById([FromRoute] int id)
        {
            try
            {
                await _dbController.DeletePersonByIdAsync(id);
                return Ok();
            }
            catch (PersonFoundException)
            {
                return NotFound();
            }            
        }
    }
}
