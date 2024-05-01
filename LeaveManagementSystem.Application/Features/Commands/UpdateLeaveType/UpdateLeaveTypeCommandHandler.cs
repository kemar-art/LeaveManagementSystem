using AutoMapper;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeavetypecRepository _leavetypecRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeavetypecRepository leavetypecRepository)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //Convert to domain entity object
            var leavetypeToUpdate = _mapper.Map<Leavetype>(request);

            //add to database
            await _leavetypecRepository.UpdateAsync(leavetypeToUpdate);

            //Return record Id
            return Unit.Value;
        }
    }
}
