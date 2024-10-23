using BloodDonationDatabase.Application.Commands.BloodStockCommand.DeleteBloodStock;
using BloodDonationDatabase.Application.Commands.BloodStockCommand.InsertBloodStock;
using BloodDonationDatabase.Application.Commands.BloodStockCommand.UpdateBloodStock;
using BloodDonationDatabase.Application.Commands.BloodStockCommand.UpdateQuantityBloodStock;
using BloodDonationDatabase.Application.Notification;
using BloodDonationDatabase.Application.Queries.BloodStockQueries.GetAllBloodStock;
using BloodDonationDatabase.Application.Queries.BloodStockQueries.GetBloodStockById;
using BloodDonationDatabase.Application.Queries.BloodStockQueries.GetBloodStockByType;
using BloodDonationDatabase.Core.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDatabase.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBloodStockQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBloodStockByIdQuery(id));
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("{bloodType}/{rhFactor}")]
        public async Task<IActionResult> GetByType(int bloodType, int rhFactor)
        {
            var result = await _mediator.Send(new GetBloodStockByTypeQuery((BloodType)bloodType, (RhFactor)rhFactor));
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), result.Data, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBloodStockCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPut("{id}/withdraw")]
        public async Task<IActionResult> WithdrawBlood(int id, UpdateQuantityBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            await _mediator.Publish(new OutOfStockNotification
            {
               Id = id,
            });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBloodStockCommand(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}