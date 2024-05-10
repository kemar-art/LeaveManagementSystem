using AutoMapper;
using LeaveManagementApplication.UnitTests.Mocks;
using LeaveManagementSystem.Application.Contracts.ILogging;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Queries.GetAllLeaveTypes;
using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Queries.GetLeaveTypeDetails;
using LeaveManagementSystem.Application.MappingConfig;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementApplication.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeListQueryHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetAllLeaveTypeQueryHandler>> _mockAppLogger;

        public GetLeaveTypeListQueryHandlerTest() 
        { 
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeavetypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockAppLogger = new Mock<IAppLogger<GetAllLeaveTypeQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetAllLeaveTypeQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetAllLeaveTypeQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();
        }
    }
}
