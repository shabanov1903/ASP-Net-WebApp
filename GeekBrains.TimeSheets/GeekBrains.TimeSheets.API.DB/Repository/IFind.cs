using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Repository
{
    public interface IFind<Tcontext,Uparamener>
    {
        public Task<Tcontext> FindElement(Uparamener parameter);
    }
}
