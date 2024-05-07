using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.CreeateLeaveType;
using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.DeleteLeaveType;
using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.UpdateLeaveType;
using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Queries.GetLeaveAllocationDetails;
using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Queries.GetLeaveAllocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<LeaveAllocationDto>>> Get( bool isLoggedInUser = false)
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListQuery());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDetailsDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailQuery { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateLeaveAllocationCommand createLeaveAllocation)
        {
            var response = await _mediator.Send(createLeaveAllocation);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveAllocationCommand updateLeaveAllocation)
        {
            await _mediator.Send(updateLeaveAllocation);
            return Ok(updateLeaveAllocation);
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return Ok(command);
        }
    }
}
