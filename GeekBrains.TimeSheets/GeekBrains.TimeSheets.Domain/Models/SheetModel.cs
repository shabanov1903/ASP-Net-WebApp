using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.Domain.Models
{
    public class SheetModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid EmployeeId { get; set; }
        public int Amount { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
    }
}
