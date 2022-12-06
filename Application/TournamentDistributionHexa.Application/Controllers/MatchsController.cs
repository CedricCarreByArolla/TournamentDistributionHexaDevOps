using Microsoft.AspNetCore.Mvc;

namespace TournamentDistributionHexa.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchsController : ControllerBase
    {

        private readonly ILogger<MatchsController> _logger;
        /*private readonly IMatchDomain _matchDomain;

        public MatchsController(ILogger<MatchsController> logger, IMatchDomain matchDomain)
        {
            _logger = logger;
            _matchDomain = matchDomain;
        }

        [HttpGet]
        [Route("BurndownChartLines/{id}")]
        public IEnumerable<BurndownChartLineDTO> GetBurdownChartLines(int id)
        {
            return _matchDomain.GetBurndownChartLineDTOs(id);
        }
        [HttpGet]
        [Route("{id}")]
        public MatchDTO GetById(int id)
        {
            return _matchDomain.GetById(id);
        }*/
    }
}