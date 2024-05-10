using AutoMapper;
using LeaveManagementSystem.UI.Models.LeaveType;
using LeaveManagementSystem.UI.Services.Base;
using LeaveManagementSystem.UI.Services.Contracts;

namespace LeaveManagementSystem.UI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;

        public LeaveTypeService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
        {
            //try
            //{
            //    var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
            //    await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            throw new NotImplementedException();
        }

        public Task<Response<Guid>> DeleteLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LeaveTypeVM>> GetAllLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<IEnumerable<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<LeaveTypeVM> GetLeaveTypeById(int id)
        {
            var leaveType = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }
    }
}
