using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.Domain.Models;
using System.Reflection;
using System.Text;

namespace GeekBrains.TimeSheets.API.Services
{
    public class MapperService
    {
        public UserDTO Map(UserContext context)
        {
            return new UserDTO()
            {
                Id = context.Id,
                Username = context.Username,
                PasswordHash = Convert.ToBase64String(context.PasswordHash),
                Role = context.Role,
                Salt = Convert.ToBase64String(context.Salt),
                RefreshToken = context.RefreshToken
            };
        }

        public EmployeeDTO Map(EmployeeContext context)
        {
            return new EmployeeDTO()
            {
                Id = context.Id,
                UserId = context.UserId,
                IsDeleted = context.IsDeleted
            };
        }

        public SheetDTO Map(SheetContext context)
        {
            return new SheetDTO()
            {
                Id = context.Id,
                Date = context.Date,
                EmployeeId = context.EmployeeId,
                Amount = context.Amount,
                IsApproved = context.IsApproved,
                ApprovedDate = context.ApprovedDate
            };
        }

        public UserContext Map(UserDTO dto)
        {
            return new UserContext()
            {
                Id = dto.Id,
                Username = dto.Username,
                PasswordHash = Convert.FromBase64String(dto.PasswordHash),
                Role = dto.Role,
                Salt = Convert.FromBase64String(dto.Salt),
                RefreshToken = dto.RefreshToken
            };
        }

        public EmployeeContext Map(EmployeeDTO dto)
        {
            return new EmployeeContext()
            {
                Id = dto.Id,
                UserId = dto.UserId,
                IsDeleted = dto.IsDeleted
            };
        }

        public InvoiceContext Map(InvoiceDTO dto)
        {
            var invoice = new InvoiceModel().Create(dto.Id, dto.UserId, dto.Month, dto.Sum);
            return Map(invoice);
        }

        public InvoiceContext Map(InvoiceModel model)
        {
            return new InvoiceContext()
            {
                Id = model.Id,
                UserId = model.UserId,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Sum = model.Sum
            };
        }

        public List<SheetDTO> Map(List<SheetModel> listOfModel)
        {
            var result = new List<SheetDTO>();
            foreach (var sheet in listOfModel)
            {
                result.Add(new SheetDTO()
                {
                    Id = sheet.Id,
                    Date = sheet.Date,
                    EmployeeId = sheet.EmployeeId,
                    Amount = sheet.Amount,
                    IsApproved = sheet.IsApproved,
                    ApprovedDate = sheet.ApprovedDate
                });
            }
            return result;
        }

        public List<SheetModel> Map(List<SheetDTO> listOfDTO)
        {
            var result = new List<SheetModel>();
            foreach (var sheet in listOfDTO)
            {
                result.Add(new SheetModel()
                {
                    Id = sheet.Id,
                    Date = sheet.Date,
                    EmployeeId = sheet.EmployeeId,
                    Amount = sheet.Amount,
                    IsApproved = sheet.IsApproved,
                    ApprovedDate = sheet.ApprovedDate
                });
            }
            return result;
        }
    }
}
