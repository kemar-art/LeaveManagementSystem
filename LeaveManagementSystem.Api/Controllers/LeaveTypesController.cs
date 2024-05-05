using LeaveManagementSystem.Application.Features.Commands.CreeateLeaveType;
using LeaveManagementSystem.Application.Features.Commands.DeleteLeaveType;
using LeaveManagementSystem.Application.Features.Commands.UpdateLeaveType;
using LeaveManagementSystem.Application.Features.Queries.GetAllLeaveTypes;
using LeaveManagementSystem.Application.Features.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<IEnumerable<LeaveTypeDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetAllLeaveTypeQuery());
            return leaveTypes;
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveTypeCommand createLeaveType)
        {
            var response = await _mediator.Send(createLeaveType);
            return CreatedAtAction(nameof(Get), new { response});
        }

        // PUT api/<LeaveTypesController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveTypeCommand leaveType)
        {
            var updateLeaveType = await _mediator.Send(leaveType);
            return Ok(updateLeaveType);
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteLeaveType = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(deleteLeaveType);
            return NoContent();
        }
    }
}
