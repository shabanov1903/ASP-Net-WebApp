using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Context
{
    public interface IPrimaryKey
    {
        public Guid Id { get; set; }
    }
}
