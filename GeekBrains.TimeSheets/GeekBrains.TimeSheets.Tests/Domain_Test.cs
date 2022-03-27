using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.Domain.Models;
using Moq;
using System;
using Xunit;

namespace GeekBrains.TimeSheets.Tests
{
    public class Domain_Test
    {
        [Fact]
        public void Domain_Test_Check_Create_By_Rich_Model()
        {
            Assert.IsAssignableFrom<InvoiceModel>(new InvoiceModel()
                                                     .Create(It.IsAny<Guid>(),
                                                             It.IsAny<Guid>(),
                                                             0,
                                                             0));
        }
    }
}