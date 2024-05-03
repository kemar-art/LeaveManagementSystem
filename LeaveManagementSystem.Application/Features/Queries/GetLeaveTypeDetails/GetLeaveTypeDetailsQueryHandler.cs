using AutoMapper;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Features.Queries.GetAllLeaveTypes;
using LeaveManagementSytem.Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leavetypecRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leavetypecRepository)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
        }

        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveType = await _leavetypecRepository.GetByIdAsync(request.Id);

            //Verify if the record exists
            if (leaveType == null)
                    throw new NotFoundException(nameof(Leavetype), request.Id);

            // Covert data objects to DTO objects
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

            // retrun the list of DTO objects.
            return data;
        }
    }
}
