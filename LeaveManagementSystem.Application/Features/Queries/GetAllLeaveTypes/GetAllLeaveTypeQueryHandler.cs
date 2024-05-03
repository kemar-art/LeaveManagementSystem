using AutoMapper;
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

        public GetAllLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leavetypecRepository)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
        }




        public async Task<IEnumerable<LeavetypeDto>> Handle(GetAllLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveTypes = await _leavetypecRepository.GetAllAsync();

            // Covert data objects to DTO objects
            var data = _mapper.Map< IEnumerable<LeavetypeDto>>(leaveTypes);

            // retrun the list of DTO objects.
            return data;
        }
    }
}
