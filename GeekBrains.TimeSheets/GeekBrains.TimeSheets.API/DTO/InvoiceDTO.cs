using System.ComponentModel.DataAnnotations;

namespace GeekBrains.TimeSheets.API.DTO
{
    public class InvoiceDTO
    {
        [Required]
        [RegularExpression(@"[0-z]{8}-[0-z]{4}-[0-z]{4}-[0-z]{4}-[0-z]{12}")]
        public Guid Id { get; set; }
        [Required]
        [RegularExpression(@"[0-z]{8}-[0-z]{4}-[0-z]{4}-[0-z]{4}-[0-z]{12}")]
        public Guid UserId { get; set; }
        public int Month { get; set; }
        public decimal Sum { get; set; }
        public List<SheetDTO>? Sheets { get; set; }
    }
}
