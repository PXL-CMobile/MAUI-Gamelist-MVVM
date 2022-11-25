using GameWebApi.Models;
using System.IO.Pipelines;

namespace GameWebApi.Repositories
{
    public class GameRepository
    {
        private List<Game> _games;

        /* TODO couple to a real DB (option: EF Core -> local SQL) */
        public GameRepository()
        {
            _games= new List<Game>();   
            _games.Add(new Game() { Title="GTA5", ID = 1, Genre="Shooter", Score=98});
            _games.Add(new Game() { Title="GTA6", ID = 2, Genre="Shooter", Score=100});
        }

        public async Task<List<Game>> GetGames()
        {
            return await Task.Factory.StartNew(() => { return _games; }); ;
        }

        public void AddGame(Game gameObject)
        {
            var game = _games.FirstOrDefault(game=> game.ID == gameObject.ID);
            if (game != null)
            {
                game.Title = gameObject.Title;
                game.Score = gameObject.Score; 
                game.Genre = gameObject.Genre;
            } else
            {
                var nextId = _games.Max(game => game.ID) + 1;
                gameObject.ID = nextId;
                _games.Add(gameObject);
            }
        }
    }

}
