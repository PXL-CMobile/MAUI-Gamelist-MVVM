using GamesMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesMVVM.Services
{
    public class GameService
    {
        /* TODO: do database stuff here */

        private List<Game> allGames;

        public GameService()
        {
            
            allGames = new List<Game>();
            
            allGames.Add(new Game() { Title = "GTA5", Score = 94, Genre = "Shooter" });
            allGames.Add(new Game() { Title = "Fifa2022", Score = 84, Genre = "Sports" }); 
        }

        public List<Game> GetAllGames()
        {
            return allGames;
        }

        public void AddGame(Game gameToAdd)
        {
            allGames.Add(gameToAdd);
        }
    }
}
