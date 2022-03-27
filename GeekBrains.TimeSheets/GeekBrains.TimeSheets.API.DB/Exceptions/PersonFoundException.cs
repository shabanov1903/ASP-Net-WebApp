using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Exceptions
{
    public class TimeSheetException : Exception
    {
        public TimeSheetException(string message) : base(message) { }
    }
}
