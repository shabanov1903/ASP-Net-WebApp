using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Context
{
    /// <summary> Информация о пользователе системы </summary>
    public class UserContext : IPrimaryKey
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? Salt { get; set; }
        public string? Role { get; set; }
        public string? RefreshToken { get; set; }

        public EmployeeContext? Employee { get; set; }
        public InvoiceContext? Invoice { get; set; }
    }
}
