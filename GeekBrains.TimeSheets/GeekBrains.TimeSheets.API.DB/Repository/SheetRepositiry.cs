using GeekBrains.TimeSheets.DB.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Repository
{
    public class SheetRepositiry : IFind<SheetContext,Expression<Func<SheetContext, bool>>>
    {
        protected readonly TimeSheetsDbContext _context;
        public SheetRepositiry(TimeSheetsDbContext context)
        {
            _context = context;
        }

        public async Task<SheetContext> FindElement(Expression<Func<SheetContext, bool>> parameter)
        {
            return await _context.Set<SheetContext>().SingleAsync(parameter);
        }
    }
}
