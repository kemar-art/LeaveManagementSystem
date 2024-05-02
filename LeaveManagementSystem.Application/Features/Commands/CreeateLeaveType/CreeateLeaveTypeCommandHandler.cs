using AutoMapper;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Exceptions;
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
        private readonly ILeaveTypecRepository _leavetypecRepository;

        public CreeateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypecRepository leavetypecRepository)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
        }
        public async Task<int> Handle(CreeateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreeateLeaveTypeCommandValidator(_leavetypecRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validationResult.IsValid)
                throw new BadRequestException("Invalid Leavetype",  validationResult);

            //Convert to domain entity object
            var leavetypeToCreate = _mapper.Map<Leavetype>(request);

            //add to database
            await _leavetypecRepository.CreateAsync(leavetypeToCreate);

            //Return record Id
            return leavetypeToCreate.Id;
        }
    }
}
