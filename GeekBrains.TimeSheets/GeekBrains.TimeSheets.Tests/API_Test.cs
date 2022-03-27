using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.Domain.Models;
using Moq;
using System;
using Xunit;

namespace GeekBrains.TimeSheets.Tests
{
    public class API_Test
    {
        [Fact]
        public void API_Test_Check_Hashing_And_Unhashing_Password()
        {
            string password = "test";

            UserService userService = new UserService();

            byte[] salt = userService.GetNewSalt();
            byte[] hash = userService.HashPassword(password, salt);

            Assert.True(userService.CheckHashPassword(hash, password, salt));
        }

        [Fact]
        public void API_Test_Check_Mapper()
        {
            MapperService mapperService = new MapperService();

            Assert.IsAssignableFrom<UserDTO>(mapperService.Map(new UserContext() { Id = It.IsAny<Guid>(),
                                                                                   Username = "test",
                                                                                   PasswordHash = new byte[] { 1, 2, 3, 4 },
                                                                                   Role = "test",
                                                                                   Salt = new byte[] { 1, 2, 3, 4 },
                                                                                   RefreshToken = "test" }));
            
            Assert.IsAssignableFrom<EmployeeDTO>(mapperService.Map(new EmployeeContext() { Id = It.IsAny<Guid>(),
                                                                                           UserId = It.IsAny<Guid>(),
                                                                                           IsDeleted = false }));
            
            Assert.IsAssignableFrom<UserContext>(mapperService.Map(new UserDTO() { Id = It.IsAny<Guid>(),
                                                                                   Username = "test",
                                                                                   PasswordHash = "test",
                                                                                   Role = "test",
                                                                                   Salt = "test",
                                                                                   RefreshToken = "test" }));

            Assert.IsAssignableFrom<EmployeeContext>(mapperService.Map(new EmployeeDTO() { Id = It.IsAny<Guid>(),
                                                                                           UserId = It.IsAny<Guid>(),
                                                                                           IsDeleted = false }));

            Assert.IsAssignableFrom<InvoiceContext>(mapperService.Map(new InvoiceDTO() { Id = It.IsAny<Guid>(),
                                                                                         UserId = It.IsAny<Guid>(),
                                                                                         Month = 0,
                                                                                         Sum = 0 }));
            
            Assert.IsAssignableFrom<InvoiceContext>(mapperService.Map(new InvoiceModel().Create(It.IsAny<Guid>(),
                                                                                                It.IsAny<Guid>(),
                                                                                                0,
                                                                                                0)));
        }
    }
}