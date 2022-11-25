using GameWebApi.Models;
using GameWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;

namespace GameWebApi.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly GameRepository _gameRepo;

        public GameController(GameRepository repo)
        {
            _gameRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var allGames = await _gameRepo.GetGames();
            return Ok(allGames);
        }

        [HttpPost]
        public async Task<IActionResult> PostGame([FromBody]Game gameObject)
        {
            _gameRepo.AddGame(gameObject);
            return CreatedAtAction(nameof(PostGame), gameObject);
        }
    }
}
