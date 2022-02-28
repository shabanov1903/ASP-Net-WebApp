using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Context
{
    /// <summary> Информация о затраченном времени сотрудника </summary>
    public class SheetContext : IPrimaryKey
    {
        public Guid Id { get; set; }
        public DateTime Date { get; protected set; }
        public Guid EmployeeId { get; protected set; }
        public int Amount { get; protected set; }
        public bool IsApproved { get; protected set; }
        public DateTime ApprovedDate { get; protected set; }
        public EmployeeContext? Employee { get; set; }
        public InvoiceContext? Invoice { get; set; }
    }
}
