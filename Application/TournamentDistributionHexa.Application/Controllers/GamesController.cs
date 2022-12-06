using Microsoft.AspNetCore.Mvc;

namespace TournamentDistributionHexa.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        /*private readonly IJeuDomain _JeuDomain;

        public GamesController(IJeuDomain JeuDomain)
        {
            _logger = logger;
            _JeuDomain = JeuDomain;
        }

        [HttpGet]
        public IEnumerable<JeuDTO> GetAll()
        {
            return _JeuDomain.GetAll();
        }
        [HttpPost]
        public async Task<JeuDTO> Create(JeuDTO Jeu)
        {
            return await _JeuDomain.Create(Jeu);
        }
        [HttpPut]
        public async Task<JeuDTO> Update(JeuDTO Jeu)
        {
            return await _JeuDomain.Update(Jeu);
        }
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _JeuDomain.Delete(id);
        }*/
    }
}