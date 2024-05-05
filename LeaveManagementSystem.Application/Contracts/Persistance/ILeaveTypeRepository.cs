﻿using LeaveManagementSytem.Domian;

namespace LeaveManagementSystem.Application.Contracts.Persistance
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
