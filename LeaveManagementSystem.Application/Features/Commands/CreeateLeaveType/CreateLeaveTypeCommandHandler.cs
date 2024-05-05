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
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, LeaveType>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leavetypecRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leavetypecRepository)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
        }

        public async Task<LeaveType> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leavetypecRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leave type", validationResult);
            }


            //Convert to domain entity object
            var leavetypeToCreate = _mapper.Map<LeaveType>(request);

            //add to database
            await _leavetypecRepository.CreateAsync(leavetypeToCreate);

            //Return record Id
            return leavetypeToCreate;
        }

        //public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        //{
        //    //Validate incoming data
        //    var validator = new CreateLeaveTypeCommandValidator(_leavetypecRepository);
        //    var validationResult = await validator.ValidateAsync(request);

        //    if (validationResult.Errors.Any())
        //    {
        //        throw new BadRequestException("Invalid Leave type", validationResult);
        //    }


        //    //Convert to domain entity object
        //    var leavetypeToCreate = _mapper.Map<LeaveType>(request);

        //    //add to database
        //    await _leavetypecRepository.CreateAsync(leavetypeToCreate);

        //    //Return record Id
        //    return leavetypeToCreate.Id;
        //}
    }
}
