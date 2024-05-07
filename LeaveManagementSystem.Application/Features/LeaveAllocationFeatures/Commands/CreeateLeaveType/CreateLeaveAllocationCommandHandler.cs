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

namespace LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.CreeateLeaveType
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository  leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository) 
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leave Allocation Request", validationResult);
            }

            //Get Leave type for allocation
            var leaveType = await _leaveAllocationRepository.GetByIdAsync(request.LeavetypeId);

            //Get Emloyees

            //Get Period

            //Assign Allocations
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request);
            await _leaveAllocationRepository.CreateAsync(leaveAllocation);
            return Unit.Value;
        }
    }
}
