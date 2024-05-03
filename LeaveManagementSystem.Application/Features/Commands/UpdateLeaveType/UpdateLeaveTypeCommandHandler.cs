using AutoMapper;
using FluentValidation;
using LeaveManagementSystem.Application.Contracts.ILogging;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Features.Commands.CreeateLeaveType;
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
        private readonly ILeaveTypeRepository _leavetypecRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _appLogger;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leavetypecRepository, IAppLogger<UpdateLeaveTypeCommandHandler> appLogger)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateLeaveTypeCommandValidator(_leavetypecRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _appLogger.LogWarning("Validate errors in update request for {0} - {1}", typeof(Leavetype), request.Id);
                throw new BadRequestException("Invalid Leave type", validationResult);
            }
            //Convert to domain entity object
            var leavetypeToUpdate = _mapper.Map<Leavetype>(request);

            //add to database
            await _leavetypecRepository.UpdateAsync(leavetypeToUpdate);

            //Return record Id
            return Unit.Value;
        }
    }
}
