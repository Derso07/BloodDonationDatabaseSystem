using BloodDonationDatabase.Application.Commands.DonorCommand.DeleteDonor;
using BloodDonationDatabase.Application.Commands.DonorCommand.InsertDonor;
using BloodDonationDatabase.Application.Commands.DonorCommand.UpdateDonor;
using BloodDonationDatabase.Application.Queries.DonorQueries.GetAllDonor;
using BloodDonationDatabase.Application.Queries.DonorQueries.GetDonorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDatabase.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertDonorAdressCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(GetById),new { result.Data }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDonorByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDonorQuery());

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDonorCommand command)
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
            var result = await _mediator.Send(new DeleteDonorCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


    }
}
