﻿using AutoMapper;
using FluentValidation;
using LeaveManagementSystem.Application.Contracts.ILogging;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Commands.CreeateLeaveType;
using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Commands.UpdateLeaveType;
using LeaveManagementSytem.Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, LeaveType>
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
        public async Task<LeaveType> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateLeaveTypeCommandValidator(_leavetypecRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                _appLogger.LogWarning("Validate errors in update request for {0} - {1}", typeof(LeaveType), request.Id);
                throw new BadRequestException("Invalid Leave type", validationResult);
            }
            //Convert to domain entity object
            var leavetypeToUpdate = _mapper.Map<LeaveType>(request);

            //add to database
            await _leavetypecRepository.UpdateAsync(leavetypeToUpdate);

            //Return record Id
            return leavetypeToUpdate;
        }
    }
}
