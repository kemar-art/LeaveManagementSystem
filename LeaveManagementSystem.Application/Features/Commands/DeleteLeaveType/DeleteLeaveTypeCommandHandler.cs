using AutoMapper;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand ,Unit>
    {
        private readonly ILeavetypecRepository _leavetypecRepository;

        public DeleteLeaveTypeCommandHandler(ILeavetypecRepository leavetypecRepository) 
        {
            _leavetypecRepository = leavetypecRepository;
        }
   
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //Find domain entity object
            var leavetypeTodelete = await _leavetypecRepository.GetByIdAsync(request.Id);

            //Verifiy if the record exists


            //Remove from database
            await _leavetypecRepository.DeleteAsync(leavetypeTodelete);

            //Return record Id
            return Unit.Value;
        }
    }
}
