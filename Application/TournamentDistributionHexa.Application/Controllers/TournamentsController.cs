using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TournamentDistributionHexa.Application.Commands;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Queries;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GetTournamentResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> All()
        {
            return Ok(await _mediator.Send(new GetAllTournamentsQuery()));
        }
        [HttpGet]
        [Route("{id}/Scores")]
        [ProducesResponseType(typeof(List<GetScoreResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetScoresByTournamentId(long id)
        {
            return Ok(await _mediator.Send(new GetTournamentScoresQuery(id)));
        }
        [HttpGet]
        [Route("{id}/Scores/Players/{playerId}")]
        [ProducesResponseType(typeof(List<GetScoreResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetScoresByTournamentIdAndPlayerId(long id, long playerId)
        {
            return Ok(await _mediator.Send(new GetTournamentScoresByPlayerQuery(id, playerId)));
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<TournamentMatch>), (int)HttpStatusCode.Created)]
        public IActionResult Create([FromBody] CreateTournamentRequest tournoi)
        {
            return Created(string.Empty, _mediator.Send(new CreateTournamentCommand(tournoi)));
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<TournamentMatch>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] EditTournamentRequest tournoi)
        {
            return Ok(await _mediator.Send(new EditTournamentCommand(tournoi)));
        }
    }
}