using FluentValidation;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Shaired;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.CreeateLeaveRequest
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository) 
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new BaseLeaveRequestValidator(leaveTypeRepository));
        }
    }
}
