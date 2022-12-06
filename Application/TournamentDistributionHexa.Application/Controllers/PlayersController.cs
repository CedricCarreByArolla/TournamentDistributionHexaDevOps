using Microsoft.AspNetCore.Mvc;
using TournamentDistributionHexa.Domain.Players;

namespace TournamentDistributionHexa.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JoueursController : ControllerBase
    {

        private readonly ILogger<JoueursController> _logger;
        private readonly IPlayerDomain _playerDomain;

        public JoueursController(ILogger<JoueursController> logger, IPlayerDomain joueurDomain)
        {
            _logger = logger;
            _playerDomain = joueurDomain;
        }
        /*
        [HttpGet]
        public IEnumerable<JoueurDTO> GetAll()
        {
            return _playerDomain.GetAll();
        }
        [HttpPost]
        public async Task<JoueurDTO> Create(JoueurDTO joueur)
        {
            return await _playerDomain.Create(joueur);
        }
        [HttpPut]
        public async Task<JoueurDTO> Update(JoueurDTO joueur)
        {
            return await _playerDomain.Update(joueur);
        }
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _playerDomain.Delete(id);
        }*/
    }
}