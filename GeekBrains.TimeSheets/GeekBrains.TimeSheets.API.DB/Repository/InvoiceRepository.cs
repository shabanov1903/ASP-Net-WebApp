using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.Domain.Operations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Repository
{
    public class InvoiceRepository : IDomainRepository<InvoiceContext>
    {
        protected readonly TimeSheetsDbContext _context;
        public InvoiceRepository(TimeSheetsDbContext context)
        {
            _context = context;
        }

        public async Task Create(InvoiceContext context)
        {
            await _context.Set<InvoiceContext>().AddAsync(context);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var element = await _context.Set<InvoiceContext>().SingleAsync(x => x.Id == id);
            _context.Set<InvoiceContext>().Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<InvoiceContext> Read(Guid id)
        {
            var element = await _context.Set<InvoiceContext>().SingleAsync(x => x.Id == id);
            return element;
        }

        public async Task Update(InvoiceContext context)
        {
            var element = await _context.Set<InvoiceContext>().SingleAsync(x => x.Id == context.Id);
            element.Id = context.Id;
            element.UserId = context.UserId;
            element.DateStart = context.DateStart;
            element.DateEnd = context.DateEnd;
            element.Sum = context.Sum;
            await _context.SaveChangesAsync();
        }
    }
}
