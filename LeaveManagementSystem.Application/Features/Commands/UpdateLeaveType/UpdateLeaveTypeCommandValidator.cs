using FluentValidation;
using LeaveManagementSystem.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypecRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leavetypecRepository) 
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .MustAsync(LeaveTypeMustExist);

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.DefaultDays)
                .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
                .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");


            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave type already exists");

            _leaveTypecRepository = leavetypecRepository;

        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
        {
            var leaveType = await _leaveTypecRepository.GetByIdAsync(id);
            return leaveType != null;
        }

        private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            return await _leaveTypecRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
