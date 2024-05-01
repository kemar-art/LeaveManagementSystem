﻿using AutoMapper;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSystem.Application.Features.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeavetypecRepository _leavetypecRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeavetypecRepository leavetypecRepository)
        {
            _mapper = mapper;
            _leavetypecRepository = leavetypecRepository;
        }

        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveType = await _leavetypecRepository.GetByIdAsync(request.Id);

            // Covert data objects to DTO objects
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

            // retrun the list of DTO objects.
            return data;
        }
    }
}