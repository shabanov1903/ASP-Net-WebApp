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
    public class UserRepositiry : Repository<UserContext>, IFind<UserContext,Expression<Func<UserContext, bool>>>
    {
        public UserRepositiry(TimeSheetsDbContext context) : base(context)
        { }

        public async Task<UserContext> FindElement(Expression<Func<UserContext, bool>> parameter)
        {
            return await _context.Set<UserContext>().SingleAsync(parameter);
        }

        public override async Task Update(UserContext context)
        {
            var element = await _context.Set<UserContext>().SingleAsync(x => x.Id == context.Id);
            element.Id = context.Id;
            element.Username = context.Username;
            element.PasswordHash = context.PasswordHash;
            element.Role = context.Role;
            await _context.SaveChangesAsync();
        }
    }
}
