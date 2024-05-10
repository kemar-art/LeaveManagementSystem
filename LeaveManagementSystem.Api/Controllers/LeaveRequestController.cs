using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.UpdateLeaveType;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.CancelLeaveRequest;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.ChangeLeaveRequestApproval;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.CreeateLeaveRequest;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.DeleteLeaveRequest;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.UpdateLeaveRequest;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Queries.GetLeaveRequestDetails;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Queries.GetLeaveRequestList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequestListDto>>> Get()
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestListQuery());
            return Ok(leaveRequest);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDetailsDto>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailsQuery { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveRequestCommand leaveRequest)
        {
            var response = await _mediator.Send(leaveRequest);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // POST api/<LeaveRequestController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveRequestCommand updateLeaveRequest)
        {
            await _mediator.Send(updateLeaveRequest);
            return Ok(updateLeaveRequest);
        }

        // POST api/<LeaveRequestController>
        [HttpPut]
        [Route("CancleRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancleRequest(CancelLeaveRequestCommand cancelLeaveRequest)
        {
            await _mediator.Send(cancelLeaveRequest);
            return Ok(cancelLeaveRequest);
        }

        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateApproval(ChangeLeaveRequestApprovalCommand leaveRequestApprovalCommand)
        {
            await _mediator.Send(leaveRequestApprovalCommand);
            return Ok(leaveRequestApprovalCommand);
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
    
}
