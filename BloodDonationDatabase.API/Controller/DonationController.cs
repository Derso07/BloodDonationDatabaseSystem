using BloodDonationDatabase.Application.Commands.DonationCommand.DeleteDonation;
using BloodDonationDatabase.Application.Commands.DonationCommand.InsertDonation;
using BloodDonationDatabase.Application.Commands.DonationCommand.UpdateDonation;
using BloodDonationDatabase.Application.Queries.DonationsQueries.GetAllDonation;
using BloodDonationDatabase.Application.Queries.DonationsQueries.GetDonationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDatabase.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDonationByIdCommand(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDonationCommand());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertDonationCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById),new { id = result.Data},command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDonationCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDonationCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

    }
}
