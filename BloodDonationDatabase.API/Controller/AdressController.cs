using BloodDonationDatabase.Application.Queries.AdressQueries.GetAdressByCepQuery;
using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Infrastructure.Email;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDatabase.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdressController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public AdressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("checkadress/{cep}")]
        public async Task<IActionResult> CheckAdress([FromRoute]string cep)
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
