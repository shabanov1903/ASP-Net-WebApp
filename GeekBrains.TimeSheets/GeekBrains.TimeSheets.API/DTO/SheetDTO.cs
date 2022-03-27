namespace GeekBrains.TimeSheets.API.DTO
{
    public class SheetDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid EmployeeId { get; set; }
        public int Amount { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
    }
}
