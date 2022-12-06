using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TournamentDistributionHexa.Application.Commands;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Queries;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoresController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ScoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{matchId}")]
        [ProducesResponseType(typeof(Score), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(long matchId, long joueurId)
        {
            return Ok(await _mediator.Send(new GetScoreQuery(matchId, joueurId)));
        }
        [HttpPut]
        [ProducesResponseType(typeof(Score), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] EditScoreRequest scoreRequest)
        {
            return Ok(await _mediator.Send(new EditScoreCommand(scoreRequest)));
        }
    }
}