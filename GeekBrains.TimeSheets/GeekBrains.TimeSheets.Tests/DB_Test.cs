using GeekBrains.TimeSheets.API.Controllers;
using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Repository;
using GeekBrains.TimeSheets.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GeekBrains.TimeSheets.Tests
{
    public class DB_Test
    {
        [Fact]
        public async Task DB_Test_Check_UsersController()
        {
            var mapp = new MapperService();
            var user = new UserService();
            var mockRepo = new Mock<IRepository<UserContext>>();

            var userDTO = new UserDTO()
            {
                Id = It.IsAny<Guid>(),
                Username = "test",
                PasswordHash = "test",
                Role = "test",
                Salt = "test",
                RefreshToken = "test"
            };

            mockRepo.Setup(x => x.Read(It.IsAny<Guid>())).Returns(Task.FromResult(new MapperService().Map(userDTO)));

            UsersController ctr = new UsersController(mapp, user, mockRepo.Object);

            Assert.IsAssignableFrom<IActionResult>(await ctr.Create(userDTO));
            Assert.IsAssignableFrom<IActionResult>(await ctr.Read(It.IsAny<Guid>()));
            Assert.IsAssignableFrom<IActionResult>(await ctr.Update(userDTO));
            Assert.IsAssignableFrom<IActionResult>(await ctr.Delete(It.IsAny<Guid>()));
        }

        public async Task DB_Test_Check_EmployeeController()
        {
            var mapp = new MapperService();
            var mockRepo = new Mock<IRepository<EmployeeContext>>();

            var emplDTO = new EmployeeDTO()
            {
                Id = It.IsAny<Guid>(),
                UserId = It.IsAny<Guid>(),
                IsDeleted = false
            };

            mockRepo.Setup(x => x.Read(It.IsAny<Guid>())).Returns(Task.FromResult(new MapperService().Map(emplDTO)));

            EmployeesController ctr = new EmployeesController(mapp, mockRepo.Object);

            Assert.IsAssignableFrom<IActionResult>(await ctr.Create(emplDTO));
            Assert.IsAssignableFrom<IActionResult>(await ctr.Read(It.IsAny<Guid>()));
            Assert.IsAssignableFrom<IActionResult>(await ctr.Update(emplDTO));
            Assert.IsAssignableFrom<IActionResult>(await ctr.Delete(It.IsAny<Guid>()));
        }
    }
}