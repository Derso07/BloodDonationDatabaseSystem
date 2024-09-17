using BloodDonationDatabase.Application.Queries.AdressQueries.GetAdressByCepQuery;
using BloodDonationDatabase.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDatabase.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdressController : ControllerBase
    {
        public AdressController(IMediator mediator)
        {
            mediator = _mediator;
        }
        private readonly IMediator _mediator;

        [HttpGet("checkAdress/{cep}")]
        public async Task<IActionResult> CheckAdress(string cep)
        {
            var query = new GetAdressByCepQuery(cep);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

    }
}
