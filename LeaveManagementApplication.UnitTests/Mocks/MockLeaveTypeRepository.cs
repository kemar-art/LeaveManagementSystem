using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementApplication.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation",
                },

                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Sick",
                },

                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 60,
                    Name = "Test Maternity",
                }
            };

            var mackRepo = new Mock<ILeaveTypeRepository>();
             mackRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(leaveTypes);

            mackRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });

            return mackRepo;
        }
    }
}
