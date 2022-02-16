namespace GeekBrains.TimeSheets.API.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
