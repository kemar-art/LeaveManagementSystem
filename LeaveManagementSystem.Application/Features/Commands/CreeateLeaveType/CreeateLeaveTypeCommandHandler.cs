using AutoMapper;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Commands.CreeateLeaveType
{
    public class CreeateLeaveTypeCommandHandler : IRequestHandler<CreeateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeavetypecRepository _leavetypecRepository;

        public CreeateLeaveTypeCommandHandler(IMapper mapper, ILeavetypecRepository leavetypecRepository)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
        }
        public async Task<int> Handle(CreeateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //Convert to domain entity object
            var leavetypeToCreate = _mapper.Map<Leavetype>(request);

            //add to database
            await _leavetypecRepository.CreateAsync(leavetypeToCreate);

            //Return record Id
            return leavetypeToCreate.Id;
        }
    }
}
