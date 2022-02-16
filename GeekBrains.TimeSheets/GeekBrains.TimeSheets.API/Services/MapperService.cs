using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.DB.Context;
using System.Reflection;

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
                PasswordHash = ByteToShort(context.PasswordHash),
                Role = context.Role
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
                PasswordHash = ShortToByte(dto.PasswordHash),
                Role = dto.Role
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

        private byte[] ShortToByte(short[] mass)
        {
            byte[] outputMass = new byte[mass.Length];
            for(int i = 0; i < mass.Length; i++)
            {
                outputMass[i] = (byte)mass[i];
            }
            return outputMass;
        }

        private short[] ByteToShort(byte[] mass)
        {
            short[] outputMass = new short[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                outputMass[i] = mass[i];
            }
            return outputMass;
        }
    }
}
