using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Context
{
    /// <summary> Счет сотрудника </summary>
    public class InvoiceContext : IPrimaryKey
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal Sum { get; set; }

        public UserContext? User { get; set; }
        public List<SheetContext>? Sheets { get; set; }
    }
}
