using GamesMVVM.Models;
using GamesMVVM.Repositories;
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
        private IGamesRepository gamesRepo; 
        // You could still use this to cache the list.
        // private List<Game> allGames;

        public GameService(IGamesRepository repo)
        {
            gamesRepo = repo;
            
            //allGames = new List<Game>();
        }

        public async Task<List<Game>> GetAllGames()
        {
            //allGames = await gamesRepo.GetGamesAsync();
            //return allGames;
            return await gamesRepo.GetGamesAsync();
        }

        public async void AddGame(Game gameToAdd)
        {
            await gamesRepo.SaveGameAsync(gameToAdd);
        }

        public async void SaveGame(Game gameToAdd)
        {
            await gamesRepo.SaveGameAsync(gameToAdd);
        }
    }
}
