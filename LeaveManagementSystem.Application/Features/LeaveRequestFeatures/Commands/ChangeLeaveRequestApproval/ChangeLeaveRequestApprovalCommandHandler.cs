using AutoMapper;
using LeaveManagementSystem.Application.Contracts.EmailService;
using LeaveManagementSystem.Application.Contracts.ILogging;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IAppLogger<ChangeLeaveRequestApprovalCommand> _appLogger;

        public ChangeLeaveRequestApprovalCommandHandler(IMapper mapper, IEmailService emailService, ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository, IAppLogger<ChangeLeaveRequestApprovalCommand> appLogger)
        {
            _mapper = mapper;
            _emailService = emailService;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _appLogger = appLogger;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(leaveRequest), request.Id);
            }

            leaveRequest.Approved = request.IsApproved;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            // If request is approved, get and update the employee's allocations

            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,
                    Body = $"Your leave request for {leaveRequest.StartDate} to {leaveRequest.EndDate} has been updated sucessfully.",
                    Subject = "Leave Request Submission"
                };

                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _appLogger.LogWarning(ex.Message);

            }

            return Unit.Value;  
        }
    }
}
