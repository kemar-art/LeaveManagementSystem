using FluentValidation;
using LeaveManagementSystem.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Commands.CreeateLeaveType
{
    public class CreeateLeaveTypeCommandValidator : AbstractValidator<CreeateLeaveTypeCommand>
    {
        private readonly ILeavetypecRepository _leavetypecRepository;

        public CreeateLeaveTypeCommandValidator(ILeavetypecRepository leavetypecRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.DefaultDays)
                .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
                .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave type already exists");

            _leavetypecRepository = leavetypecRepository;
        }

        private async Task<bool> LeaveTypeNameUnique(CreeateLeaveTypeCommand command, CancellationToken token)
        {
            return await _leavetypecRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
