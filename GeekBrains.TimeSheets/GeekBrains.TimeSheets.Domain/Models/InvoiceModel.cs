using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.Domain.Models
{
    public class InvoiceModel
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public DateTime DateStart { get; protected set; }
        public DateTime DateEnd { get; protected set; }
        public decimal Sum { get; protected set; }
        public List<SheetModel>? Sheets { get; set; }

        public InvoiceModel Create(Guid id, Guid Uid, int month, decimal sum)
        {
            Id = id;
            UserId = Uid;
            DateStart = DateTime.Now;
            DateEnd = DateTime.Now.AddMonths(month);
            Sum = sum;
            return this;
        }

        public InvoiceModel IncludeSheets(List<SheetModel> list)
        {
            Sheets = list;
            return this;
        }
    }
}
