using GeekBrains.TimeSheets.DB.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Repository
{
    public class EmployeeRepositiry : Repository<EmployeeContext>
    {
        public EmployeeRepositiry(TimeSheetsDbContext context) : base(context)
        { }

        public override async Task Update(EmployeeContext context)
        {
            var element = await _context.Set<EmployeeContext>().SingleAsync(x => x.Id == context.Id);
            element.Id = context.Id;
            element.UserId = context.UserId;
            element.IsDeleted = context.IsDeleted;
            await _context.SaveChangesAsync();
        }
    }
}
