using AutoMapper;
using LeaveManagementSystem.Application.Contracts.ILogging;
using LeaveManagementSystem.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Queries.GetAllLeaveTypes
{
    public class GetAllLeaveTypeQueryHandler : IRequestHandler<GetAllLeaveTypeQuery, IEnumerable<LeavetypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leavetypecRepository;
        private readonly IAppLogger<GetAllLeaveTypeQueryHandler> _appLogger;

        public GetAllLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leavetypecRepository, IAppLogger<GetAllLeaveTypeQueryHandler> appLogger)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
            _appLogger = appLogger;
        }




        public async Task<IEnumerable<LeavetypeDto>> Handle(GetAllLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveTypes = await _leavetypecRepository.GetAllAsync();

            // Covert data objects to DTO objects
            var data = _mapper.Map< IEnumerable<LeavetypeDto>>(leaveTypes);

            // retrun the list of DTO objects.
            _appLogger.LogInformation("Leave types were retrieved successfully");
            return data;
        }
    }
}
