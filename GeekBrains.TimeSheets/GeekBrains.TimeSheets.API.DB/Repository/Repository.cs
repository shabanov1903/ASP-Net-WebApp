using GeekBrains.TimeSheets.DB.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Repository
{
    public abstract class Repository<TContext> : IRepository<TContext> where TContext : class, IPrimaryKey
    {
        protected readonly TimeSheetsDbContext _context;
        public Repository(TimeSheetsDbContext context)
        {
            _context = context;
        }

        public async Task Create(TContext context)
        {
            await _context.Set<TContext>().AddAsync(context);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var element = await _context.Set<TContext>().SingleAsync(x => x.Id == id);
            _context.Set<TContext>().Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<TContext> Read(Guid id)
        {
            var element = await _context.Set<TContext>().SingleAsync(x => x.Id == id);
            return element;
        }

        public abstract Task Update(TContext context);
    }
}
