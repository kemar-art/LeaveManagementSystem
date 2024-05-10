using LeaveManagement.Persistence.DatabaseContext;
using LeaveManagementSytem.Domian;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystemPersistence.Integrationtests
{
    public class HrDatabaseContextTest
    {
        private HrDatabaseContext _hrDatabaseContext;

        public HrDatabaseContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _hrDatabaseContext = new HrDatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCtreatedValue ()
        {
            //Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation",
            };

            //Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            //Assert
            leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            //Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation",
            };

            //Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            //Assert
            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}
