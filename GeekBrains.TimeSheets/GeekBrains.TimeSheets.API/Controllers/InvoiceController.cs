using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Repository;
using GeekBrains.TimeSheets.Domain.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GeekBrains.TimeSheets.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly MapperService _mapper;
        private readonly IDomainRepository<InvoiceContext> _invoiceRepository;
        private readonly IFind<InvoiceContext, Expression<Func<InvoiceContext, bool>>> _finder;
        public InvoiceController(MapperService mapper,
                                 IDomainRepository<InvoiceContext> database,
                                 IFind<InvoiceContext, Expression<Func<InvoiceContext, bool>>> finder)
        {
            _mapper = mapper;
            _invoiceRepository = database;
            _finder = finder;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create([FromBody] InvoiceDTO dto)
        {
            try
            {
                await _invoiceRepository.Create(_mapper.Map(dto));
                return Ok();
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }            
        }
    }
}
