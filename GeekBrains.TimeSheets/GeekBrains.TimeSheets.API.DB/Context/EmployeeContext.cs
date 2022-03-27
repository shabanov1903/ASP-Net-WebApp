using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Context
{
    /// <summary> Информация о сотруднике </summary>
    public class EmployeeContext : IPrimaryKey
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<SheetContext>? Sheets { get; set; }
        public UserContext? User { get; set; }
    }
}
