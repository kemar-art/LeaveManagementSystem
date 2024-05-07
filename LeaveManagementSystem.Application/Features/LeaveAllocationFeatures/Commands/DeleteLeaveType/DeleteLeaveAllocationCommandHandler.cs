using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.DeleteLeaveType
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);


            if (leaveAllocation == null)
            {
                throw new NotFoundException(nameof(leaveAllocation), request.Id);
            }

            await _leaveAllocationRepository.DeleteAsync(leaveAllocation);

            return Unit.Value;
        }
    }
}
